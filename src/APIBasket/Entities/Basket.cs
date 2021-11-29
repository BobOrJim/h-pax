using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBasket.Entities
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public List<BasketLine> BasketLines { get; set; }
        public Guid? CouponId { get; set; }
    }
}