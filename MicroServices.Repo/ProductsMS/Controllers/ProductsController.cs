using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.MS.LifecycleStates;
using ProductsManagement.MS.Models;
using ProductsManagement.MS.Views;

namespace ProductsAPIServices.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public ActionResult<Product> Get(int id)
        {
            return new Product()
            {
                ProductId = id,
                Details = new ProductInformation()
                {
                    Description = "Mac Book Pro",
                    IsService = false,
                    IsSpecialOrder = true
                },
                Status = ProductStatus.Stocked
            };
        }
    }
}
