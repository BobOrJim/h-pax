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

        //private readonly IBasketRepository _IBasketRepository;
        private readonly IMapper _mapper;

        public BasketController(IMapper mapper)
        {
            //_IBasketRepository = basketRepository;
            _mapper = mapper;
        }



        //Im going for a few shortcuts here, this endpoint is basically a dummy,  need to get this demo running asap so i can move on to milestone 3 where the fun stuff will happen.
        [HttpPost("GetBasket")]
        public ActionResult<Basket> GetBasket([FromBody] string userGuid)
        {
            Basket newBasket = new Basket();

            Guid User = Guid.Parse(userGuid);
            newBasket.UserId = User;
            newBasket.BasketId = Guid.NewGuid();
            newBasket.BasketLines = new List<BasketLine>();

            return Ok(_mapper.Map<Models.BasketDto>(newBasket));

        }
    }
}

