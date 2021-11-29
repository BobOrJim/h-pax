using AutoMapper;

namespace APIBasket.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Entities.Basket, Models.BasketDto>();
        }
    }
}



