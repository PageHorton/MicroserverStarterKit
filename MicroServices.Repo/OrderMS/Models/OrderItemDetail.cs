using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.MS.Models
{
    public class OrderItemDetail
    {
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int Qty { get; set; }
        public float UnitPrice { get; set; }
        public float DiscountPct { get; set; }
        public float FinalPrice { get; set; }
        public bool OnOrder { get; set; }
    }
}
