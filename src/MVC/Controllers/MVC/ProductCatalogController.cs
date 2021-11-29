using IdentityModel.Client;
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
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using MVC.Repos;
using System.Web;
using System.Security.Claims;
using Common;
using MVC.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace MVC.Controllers
{
    [Route("[controller]")]
    public class ProductCatalogController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHostEnvironment _environment;
        private readonly string IDPCreatedCookieName = "h-pax.cookie";

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

        public async Task<Basket> AskGateway3_GetBasket(Guid guid)
        {
            //ProductCatalogViewModel productCatalogViewModel = new();

            HttpResponseMessage httpResponseMessage = await CallURLWithAccessToken(uri.APIGateway3 + "api/V01/ProductCatalog/GetBasket", await HttpContext.GetTokenAsync("access_token"));
            string dataAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            
            var stuff = System.Text.Json.JsonSerializer.Deserialize<Basket>(dataAsString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var asdfasdf = 12;

            return new Basket();
        }




        //NÄR USER KLICKAR PÅ ATT PRODUCT
        //1: User skall skickas till IDP (Klart, görs automatiskt med authorize)
        //2: User tilldelas en guid cookie av idp (klart)
        //3: guid läses från cookie (Klart)
        //4: Bygga basket.cs o basketlines i MVC (Klart)
        //5: Kolla om det finns en basket i session storage där jag använder user guid som nyckel.


        //6: Om det inte finns en basket så anropas Basket-microservice där en basket tas emot, anrop sker via BFF3. (user guid skickas)
        //7: Ett item lägs i basket
        //8: Basket sparas i session storage med guid som key OCH basket sparas också i viewmodel.
        //9. Om item finns skall antal ökas, annas skapas ny basketLines.
        //9: Uppdatera StarUML.
        //10: MVC vet inte struktur bakom gateway3, således skall controller byta namn till något anonymt, kanske shoppingController. Likaså skall namn i Gateway3 ändras till shoppingController.

        //20. Checkout knapp till checkout meny
        //30. Apply coupon i checkout meny (verifiera mot checkout service)
        //40. Checkot (skicka till backet för permanent storage, och vidare i systemet.


        [HttpPost("AddProductToBasket")]
        [Authorize]
        public async Task<IActionResult> AddProductToBasket(ProductCatalogViewModel productCatalogViewModel, Guid ProductId)
        {
            var b = 12;

            string UserGuidAndSessionKey = ReadCookie(IDPCreatedCookieName);
            ProductCatalogViewModel newProductCatalogViewModel = null;

            //Load Session
            newProductCatalogViewModel = LoadSessionStorage() ?? new();

            if (newProductCatalogViewModel.basket == null)
            {
                var asdfa = 12;
                newProductCatalogViewModel.basket = AskGateway3_GetBasket(Guid.Parse(UserGuidAndSessionKey)).GetAwaiter().GetResult();
                var banan = 12;
            }

            //Append text
            //var stuff = test.basket.BasketLines.Add(new BasketLine());
            var c = 12;
            //Save Session
            //if (HttpContext.Request.Cookies.ContainsKey(IDPCreatedCookieName))
            //{
            //    HttpContext.Session.SetString(ReadCookie(IDPCreatedCookieName), JsonSerializer.Serialize(newStorageViewModel));
            //}


            var a = 12;

            await Task.CompletedTask;

            return View("ProductCatalog", productCatalogViewModel);
        }


        public ProductCatalogViewModel LoadSessionStorage()
        {
            ProductCatalogViewModel productCatalogViewModel = new();
            if (HttpContext.Request.Cookies.ContainsKey(IDPCreatedCookieName)) //Load SessionStorage using Id in cookie.
            {
                string sessionKey = ReadCookie(IDPCreatedCookieName);
                string sessionString = HttpContext.Session.GetString(sessionKey);
                if (!String.IsNullOrEmpty(sessionString))
                {
                    productCatalogViewModel = JsonSerializer.Deserialize<ProductCatalogViewModel>(sessionString);
                    return productCatalogViewModel;
                }
            }
            return null;
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
                        tokenViewModel.AccessTokenHeader = Newtonsoft.Json.Linq.JValue.Parse(jwtAccessToken.Header.SerializeToJson()).ToString(Newtonsoft.Json.Formatting.Indented);
                        tokenViewModel.AccessTokenPayload = Newtonsoft.Json.Linq.JValue.Parse(jwtAccessToken.Payload.SerializeToJson()).ToString(Newtonsoft.Json.Formatting.Indented);
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
                        tokenViewModel.IdTokenHeader = Newtonsoft.Json.Linq.JValue.Parse(jwtIdToken.Header.SerializeToJson()).ToString(Newtonsoft.Json.Formatting.Indented);
                        tokenViewModel.IdTokenPayload = Newtonsoft.Json.Linq.JValue.Parse(jwtIdToken.Payload.SerializeToJson()).ToString(Newtonsoft.Json.Formatting.Indented);
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