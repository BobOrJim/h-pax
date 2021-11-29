using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;


namespace Basket.Controllers.V01
{
    [Route("api/V01/[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class BasketController : ControllerBase
    {

        //private readonly IBasketRepository _IIBasketRepository;
        private readonly IMapper _mapper;

        public BasketController(IMapper mapper)
        {
            //_IproductCatalogRepository = productCatalogRepository;
            _mapper = mapper;
        }







    }
}
