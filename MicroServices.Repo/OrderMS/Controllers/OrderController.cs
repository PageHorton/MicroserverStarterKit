using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OrderManagement.MS.Views;
using OrderManagement.MS.LifecycleStates;
using OrderManagement.MS.Models;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        public ActionResult<Order> Get(int id)
        {

            return new Order()
            {
                OrderId = 1234,
                StateOfOrder = OrderState.Open,
                Header = new OrderHeader()
                {
                    CustomerId = 5678,
                    OrderCreateDateTime = DateTime.Now.AddDays(-3),
                    TraceInformation = new List<OrderTrace>()
                    {
                        new OrderTrace() { OrderTraceState = OrderState.PreValidation, StateChangeDateTime = DateTime.Now.AddDays(-3)},
                        new OrderTrace() { OrderTraceState = OrderState.Validated, StateChangeDateTime = DateTime.Now.AddDays(-2)},
                        new OrderTrace() { OrderTraceState = OrderState.Open, StateChangeDateTime = DateTime.Now.AddDays(-2), Note = "Holding part on order"}
                    }
                },
                Detail = new List<OrderItemDetail>()
                {
                    new OrderItemDetail() { Qty = 1, ProductId = 5, ProductDescription = "Iphone Charge Station", UnitPrice = 34.90f, DiscountPct = 0, FinalPrice = 34.90f, OnOrder = false},
                    new OrderItemDetail() { Qty = 2, ProductId = 16, ProductDescription = "Charge Station Sticker", UnitPrice = 6.99f, DiscountPct = 0, FinalPrice = 6.99f, OnOrder = true}
                }
            };
                //JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}