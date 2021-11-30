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


        
        
        //[HttpPost]
        //public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        [HttpPost("GetBasket")]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
//        public async Task<IActionResult> GetBasket([FromBody] Dictionary<string, string> guid)
        public async Task<IActionResult> GetBasket([FromBody] string guid)
        {

            var a = 12;

            var BasketClient = _httpClientFactory.CreateClient().HttpClientPrep(uri.Basket, null);
            //var jsonStr = JsonSerializer.Serialize(MyObject)
            //var weatherForecast = JsonSerializer.Deserialize<MyObject>(jsonStr);
            //, "application/json"


            //string json = JsonConvert.SerializeObject(dicti, Formatting.Indented);
            //var httpContent = new StringContent(json);

            // PostAsync returns a Task<httpresponsemessage>
            //var httpResponce = Helper.Client.PostAsync(path, httpContent).Result;


            var b = 12;

            var stringContent = new StringContent(JsonSerializer.Serialize(guid), Encoding.UTF8);
            //string json = JsonConvert.SerializeObject(dicti, Formatting.Indented);
            //var httpContent = new StringContent(stringContent);

            var d = 12;
            var SecretResponse = await BasketClient.PostAsync("api/V01/Basket/GetBasket", stringContent);
            var c = 12;

            return Ok(await SecretResponse.Content.ReadAsStringAsync());
        }




    }
}