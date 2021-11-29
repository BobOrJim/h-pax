using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductController(IProductCatalogRepository productCatalogRepository, IMapper mapper)
        {
            _IproductCatalogRepository = productCatalogRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAllProducts")]
        //[AllowAnonymous]
        public ActionResult<List<Product>> GetAllProducts()
        {
            List<Product> result = _IproductCatalogRepository.ReadAllProducts();
            return Ok(_mapper.Map<List<Models.ProductDto>>(result));
        }
    }
}