using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsManagement.MS.LifecycleStates;
using ProductsManagement.MS.Models;
using ProductsManagement.MS.Views;

namespace ProductsAPIServices.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class InventoryController : Controller
    {
        
        [HttpGet]
        public ActionResult<List<ProductInventory>> Get()
        {
            return new List<ProductInventory>()
            {
                new ProductInventory() {
                    Item = new Product()
                    {
                        ProductId = 45,
                        Details = new ProductInformation()
                        {
                            Description = "Mac Book Pro",
                            IsService = false,
                            IsSpecialOrder = true
                        },
                        Status = ProductStatus.Stocked
                    },
                    InStockQty = 6,
                    ReOrderLimit = 2
                },
                new ProductInventory() {
                    Item = new Product()
                    {
                        ProductId = 62,
                        Details = new ProductInformation()
                        {
                            Description = "IPad",
                            IsService = false,
                            IsSpecialOrder = false
                        },
                        Status = ProductStatus.Stocked
                    },
                    InStockQty = 11,
                    ReOrderLimit = 5
                },
                new ProductInventory() {
                    Item = new Product()
                    {
                        ProductId = 111,
                        Details = new ProductInformation()
                        {
                            Description = "Cell Station",
                            IsService = false,
                            IsSpecialOrder = false
                        },
                        Status = ProductStatus.Comming
                    },
                    InStockQty = 0,
                    ReOrderLimit = 5
                }
            };
        }
    }
}
