using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.MS.Models
{
    public class OrderHeader
    {
        public int CustomerId { get; set; }

        public DateTime OrderCreateDateTime { get; set; }

        public List<OrderTrace> TraceInformation { get; set; }
    }
}
