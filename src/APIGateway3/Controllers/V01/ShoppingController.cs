using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using APIGateway3.Services;
using Microsoft.AspNetCore.Authorization;
using Common.Extensions;
using Microsoft.AspNetCore.Authentication;
using Common;
using System.Text;
using System.Text.Json;

namespace APIGateway3.Controllers.V01
{
    [ApiController]
    [Route("api/V01/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenFactory _tokenFactory;

        public ShoppingController(IHttpClientFactory httpClientFactory, ITokenFactory tokenFactory)
        {
            _httpClientFactory = httpClientFactory;
            _tokenFactory = tokenFactory;
        }

        [HttpGet("GetAllProducts")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllProducts()
        {
            var ProductCatalogClient = _httpClientFactory.CreateClient().HttpClientPrep(uri.ProductCatalog, null);
            var SecretResponse = await ProductCatalogClient.GetAsync("api/V01/Product/GetAllProducts");
            return Ok(await SecretResponse.Content.ReadAsStringAsync());
        }


        
        
        [HttpPost("GetBasket")]
        [Authorize(Roles = "Admin, User")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetBasket([FromBody] string userGuid)
        {
            var BasketClient = _httpClientFactory.CreateClient().HttpClientPrep(uri.Basket, null);

            HttpContent contentData = new StringContent(JsonSerializer.Serialize<string>(userGuid), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await BasketClient.PostAsync("api/V01/Basket/GetBasket", contentData);
            string dataAsString = await httpResponseMessage.Content.ReadAsStringAsync();

            return Ok(dataAsString);
        }
    }
}