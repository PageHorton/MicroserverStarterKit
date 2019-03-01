using OrderManagement.MS.LifecycleStates;
using OrderManagement.MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.MS.Views
{
    public class Order
    {
        public int OrderId { get; set; }
        public OrderState StateOfOrder { get; set; }

        public OrderHeader Header { get; set; }
        public List<OrderItemDetail> Detail { get; set; }
    }
}
