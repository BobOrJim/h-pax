using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBasket.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APIBasket.Controllers.V01
{
    [Route("api/V01/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BasketController : ControllerBase
    {

        //private readonly IProductCatalogRepository _IproductCatalogRepository;
        private readonly IMapper _mapper;

        public BasketController(IMapper mapper)
        {
            //_IproductCatalogRepository = productCatalogRepository;
            _mapper = mapper;
        }

        [HttpPost("GetBasket")]
        public ActionResult<Basket> GetBasket(Guid UserGuid)
        {

            //List<Product> result = _IproductCatalogRepository.ReadAllProducts();
            //return Ok(_mapper.Map<List<Models.ProductDto>>(result));

            return new Basket();
        }
    }
}

