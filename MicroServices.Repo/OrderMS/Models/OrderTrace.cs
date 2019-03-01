using OrderManagement.MS.LifecycleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.MS.Models
{
    public class OrderTrace
    {
        public OrderState OrderTraceState { get; set; }
        public DateTime StateChangeDateTime { get; set; }
        public string Note { get; set; }
    }
}
