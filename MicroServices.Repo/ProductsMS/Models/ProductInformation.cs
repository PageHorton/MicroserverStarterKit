using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsManagement.MS.Models
{
    public class ProductInformation
    {
        public string Description { get; set; }
        public bool IsService { get; set; }
        public bool IsSpecialOrder { get; set; }
    }
}
