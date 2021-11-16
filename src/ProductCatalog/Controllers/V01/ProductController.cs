using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Entities;
using ProductCatalog.Repository;
using System.Collections.Generic;

namespace ProductCatalog.Controllers.V01
{
    [Route("api/V01/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductController : ControllerBase
    {
        private readonly IProductCatalogRepository _IproductCatalogRepository;

        public ProductController(IProductCatalogRepository productCatalogRepository)
        {
            _IproductCatalogRepository = productCatalogRepository;
        }

        [HttpGet("GetAllProducts")]
        //[AllowAnonymous]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var c = 11;
            //Här vill jag skicka det som automapper dto


            return Ok(_IproductCatalogRepository.ReadAllProducts());
        }
    }
}