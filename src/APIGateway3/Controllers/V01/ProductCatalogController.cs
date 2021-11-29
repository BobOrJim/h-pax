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

namespace APIGateway3.Controllers.V01
{
    [ApiController]
    [Route("api/V01/[controller]")]
    public class ProductCatalogController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenFactory _tokenFactory;

        public ProductCatalogController(IHttpClientFactory httpClientFactory, ITokenFactory tokenFactory)
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

        [HttpGet("GetBasket")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBasket()
        {
            var BasketClient = _httpClientFactory.CreateClient().HttpClientPrep(uri.ProductCatalog, null);
            var SecretResponse = await BasketClient.GetAsync("api/V01/Product/GetAllProducts");
            return Ok(await SecretResponse.Content.ReadAsStringAsync());
        }



        //api/V01/ProductCatalog/GetBasket
    }
}