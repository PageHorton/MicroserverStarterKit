using ProductsManagement.MS.LifecycleStates;
using ProductsManagement.MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsManagement.MS.Views
{
    public class Product
    {
        public int ProductId { get; set; }

        public ProductStatus Status { get; set; }

        public ProductInformation Details { get; set; }
    }
}
