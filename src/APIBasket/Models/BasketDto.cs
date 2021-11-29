using APIBasket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBasket.Models
{
    public class BasketDto
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public List<BasketLine> BasketLines { get; set; }
        public Guid? CouponId { get; set; }

    }
}
