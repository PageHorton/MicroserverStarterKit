using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsManagement.MS.Views
{
    public class ProductInventory
    {
        public Product Item { get; set; }
        public int InStockQty { get; set; }
        public int ReOrderLimit { get; set; }
    }
}
