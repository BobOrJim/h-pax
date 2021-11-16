using AutoMapper;

namespace ProductCatalog.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>();
        }
    }
}
