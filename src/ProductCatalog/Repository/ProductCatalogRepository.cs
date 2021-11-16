using ProductCatalog.DbContexts;
using ProductCatalog.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalog.Repository
{
    public class ProductCatalogRepository : IProductCatalogRepository
    {
        private readonly ProductCatalogDbContext _applicationDbContext;

        public ProductCatalogRepository(ProductCatalogDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<Product> ReadAllProducts()
        {
            var rows = from row in _applicationDbContext.Products select row;
            return rows.ToList();
        }
    }
}
