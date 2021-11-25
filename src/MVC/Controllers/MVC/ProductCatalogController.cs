﻿using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using MVC.Repos;
using System.Web;
using System.Security.Claims;
using Common;
using MVC.Models;

namespace MVC.Controllers
{
    [Route("[controller]")]
    public class ProductCatalogController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHostEnvironment _environment;

        public ProductCatalogController(IHttpClientFactory httpClientFactory, IHostEnvironment environment)
        {
            _httpClientFactory = httpClientFactory;
            _environment = environment;
        }


        [HttpGet("AskGateway3_GetAllProducts")]
        [Authorize]
        public async Task<IActionResult> AskGateway3_GetAllProducts()
        {
            ProductCatalogViewModel productCatalogViewModel = new();

            HttpResponseMessage httpResponseMessage = await CallURLWithAccessToken(uri.APIGateway3 + "api/V01/ProductCatalog/GetAllProducts", await HttpContext.GetTokenAsync("access_token"));
            string dataAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            productCatalogViewModel.RawDataFromHttpResponse = dataAsString;
            List<Product> stuff = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(dataAsString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            productCatalogViewModel.Products = stuff;
            
            return View("ProductCatalog", productCatalogViewModel);
        }



        //1: User skall skickas till IDP (Klart, görs automatiskt med authorize)
        //2: User tilldelas en guid cookie av idp (klart)
        //3: guid läses från cookie

        //Kolla om det finns en basket i session storage
        //Om det inte finns en basket så skapar vi en.
        //4: guid skickas i anrop till basket microservice, som returnerar en basket.
        //5: Ett item lägs i basket
        //6: Basket sparas i session storage med guid som key.basket sparas även i viewmodel.

        [HttpPost("AddProductToBasket")]
        [Authorize]
        public async Task<IActionResult> AddProductToBasket(ProductCatalogViewModel productCatalogViewModel, Guid Id)
        {

            string UserGuidAndSessionKey = ReadCookie("h-pax.cookie");

            //Load Session
            StorageViewModel newStorageViewModel = LoadSessionStorage(storageViewModel);
            //Append text
            newStorageViewModel.StringStorage += TextToAdd;
            //Save Session
            if (HttpContext.Request.Cookies.ContainsKey("user.cookie"))
            {
                HttpContext.Session.SetString(ReadCookie("user.cookie"), JsonSerializer.Serialize(newStorageViewModel));
            }

            var a = 12;



            await Task.CompletedTask;

            return View("ProductCatalog", productCatalogViewModel);
        }


        public string ReadCookie(string key)
        {
            return Request.Cookies[key];
        }


        public async Task<HttpResponseMessage> CallURLWithAccessToken(string url, string accessToken)
        {
            UpdateInMemoryTokenRepo();
            await UseRefreshTokenIfAccessTokenIsOld();
            UpdateInMemoryTokenRepo();
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.SetBearerToken(accessToken);
            return await httpClient.GetAsync(url);
        }
        private async Task UseRefreshTokenIfAccessTokenIsOld()
        {
            if (InMemoryTokenRepo.AccessTokenLifeLeftPercent < 0.85)
            {
                var serverClient = _httpClientFactory.CreateClient();
                var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync(uri.IDP);

                var accessToken = HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();
                var idToken = await HttpContext.GetTokenAsync("id_token");
                var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
                var refreshTokenClient = _httpClientFactory.CreateClient();

                if (!string.IsNullOrEmpty(refreshToken))
                {
                    var tokenResponse = await refreshTokenClient.RequestRefreshTokenAsync(
                    new RefreshTokenRequest
                    {
                        Address = discoveryDocument.TokenEndpoint,
                        RefreshToken = refreshToken,
                        ClientId = "client_mvc",
                        ClientSecret = "client_secret_mvc"
                    });
                    var authInfo = await HttpContext.AuthenticateAsync("mvc_client_cookie");
                    authInfo.Properties.UpdateTokenValue("access_token", tokenResponse.AccessToken);
                    authInfo.Properties.UpdateTokenValue("id_token", tokenResponse.IdentityToken);
                    authInfo.Properties.UpdateTokenValue("refresh_token", tokenResponse.RefreshToken);
                    await HttpContext.SignInAsync("mvc_client_cookie", authInfo.Principal, authInfo.Properties);
                }
                UpdateInMemoryTokenRepo();
            }
        }
        public void UpdateInMemoryTokenRepo()
        {
            if (_environment.IsDevelopment())
            {
                var accessToken = HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();
                InMemoryTokenRepo.SetAccessToken(accessToken);
                var idToken = HttpContext.GetTokenAsync("id_token").GetAwaiter().GetResult();
                InMemoryTokenRepo.SetIdToken(idToken);
                var refreshToken = HttpContext.GetTokenAsync("refresh_token").GetAwaiter().GetResult();
                InMemoryTokenRepo.SetRefreshToken(refreshToken);
            }
        }
        public async Task<TokenViewModel> TokenViewModelFactory()
        {
            TokenViewModel tokenViewModel = new TokenViewModel();
            if (_environment.IsDevelopment())
            {

                //Step1: Add access_token to InMemoryTokenRepo & to the TokenViewModel
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    var jwtAccessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
                    var accessTokenLifetimeLeft = jwtAccessToken.ValidTo.AddMinutes(5) - DateTime.UtcNow; //Calculate accesstoken lifetime left. The 5 extra minutes is due to the default mintime in is4
                    var accessTokenTotalLifetime = jwtAccessToken.ValidTo.AddMinutes(5) - jwtAccessToken.ValidFrom; 
                    InMemoryTokenRepo.AccessTokenLifeLeftPercent = accessTokenLifetimeLeft.TotalSeconds / accessTokenTotalLifetime.TotalSeconds;
                    tokenViewModel.AccessTokenLifeLeftPercent = InMemoryTokenRepo.AccessTokenLifeLeftPercent * 100.0;
                    if (!string.IsNullOrEmpty(InMemoryTokenRepo.AccessToken))
                    {
                        tokenViewModel.AccessTokenHeader = JValue.Parse(jwtAccessToken.Header.SerializeToJson()).ToString(Formatting.Indented);
                        tokenViewModel.AccessTokenPayload = JValue.Parse(jwtAccessToken.Payload.SerializeToJson()).ToString(Formatting.Indented);
                        tokenViewModel.AccessToken_nbf = jwtAccessToken.ValidFrom.ToString("yyyy-MM-dd HH:mm:ss");
                        tokenViewModel.AccessToken_exp = jwtAccessToken.ValidTo.ToString("yyyy-MM-dd HH:mm:ss");
                        tokenViewModel.AccessToken_auth_time = jwtAccessToken.IssuedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }

                //Step2: Add id_token to InMemoryTokenRepo & to the TokenViewModel
                var idToken = await HttpContext.GetTokenAsync("id_token");
                if (!string.IsNullOrEmpty(idToken))
                {
                    var jwtIdToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
                    //Calculate idtoken lifetime left. The 5 extra minutes is due to the default mintime in is4
                    var idTokenLifetimeLeft = jwtIdToken.ValidTo.AddMinutes(5) - DateTime.UtcNow;
                    var idTokenTotalLifetime = jwtIdToken.ValidTo.AddMinutes(5) - jwtIdToken.ValidFrom;
                    InMemoryTokenRepo.IdTokenLifeLeftPercent = idTokenLifetimeLeft.TotalSeconds / idTokenTotalLifetime.TotalSeconds;
                    tokenViewModel.IdTokenLifeLeftPercent = InMemoryTokenRepo.IdTokenLifeLeftPercent * 100.0;
                    if (!string.IsNullOrEmpty(InMemoryTokenRepo.IdToken))
                    {
                        tokenViewModel.IdTokenHeader = JValue.Parse(jwtIdToken.Header.SerializeToJson()).ToString(Formatting.Indented);
                        tokenViewModel.IdTokenPayload = JValue.Parse(jwtIdToken.Payload.SerializeToJson()).ToString(Formatting.Indented);
                        tokenViewModel.IdToken_nbf = jwtIdToken.ValidFrom.ToString("yyyy-MM-dd HH:mm:ss");
                        tokenViewModel.IdToken_exp = jwtIdToken.ValidTo.ToString("yyyy-MM-dd HH:mm:ss");
                        tokenViewModel.IdToken_auth_time = jwtIdToken.IssuedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }

                //Step3: Add refresh_token to the TokenViewModel
                tokenViewModel.RefreshTokenCode = InMemoryTokenRepo.RefreshToken ?? "";

            }

            //Step4: Move timestamp Latest-update-in-InMemoryTokenRepo to tokenViewModel
            tokenViewModel.TimeStampLatestUpdate = new DateTime(InMemoryTokenRepo.TimestampLastAccessTokenUpdate).ToString("yyyy-MM-dd HH:mm:ss");
            return tokenViewModel;
        }
    }
}