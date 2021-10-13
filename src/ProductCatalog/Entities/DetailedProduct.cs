using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Entities
{
    public class DetailedProduct
    {

        public Guid Id { get; set; }                 
        public string Description { get; set; }
        public Product Product { get; set; }        //For Fluent
        public int ProductIdFK { get; set; }        //For Fluent. Link between this, and to Product PK

    }
}
