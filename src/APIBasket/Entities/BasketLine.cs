
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBasket.Entities
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
    }
}
