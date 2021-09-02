using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightweightArchitectureWebApi.DomainModel
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public short Status { get; set; }
    }
}
