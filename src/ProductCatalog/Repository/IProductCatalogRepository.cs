using ProductCatalog.Entities;
using System.Collections.Generic;

namespace ProductCatalog.Repository
{
    public interface IProductCatalogRepository
    {
        List<Product> ReadAllProducts();
    }
}