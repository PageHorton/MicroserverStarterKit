namespace CustomersAPIServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using CustomersManagement.MS.Views;
    using CustomersManagement.MS.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("api/[controller]")]
    [Authorize]
    public class CustomersController : Controller
    {        
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return new List<Customer>() {
                new Customer()
                {
                    CustomerId = 123,
                    CustomerDemographicInfo = new Demographics()
                    {
                        DateOfBirth = new DateTime(1982, 7, 24),
                        Sex = PersonSex.Male
                    },
                    Information = new PersonalInformation()
                    {
                        FirstName = "Sam",
                        LastName = "Jones"
                    }
                },
                new Customer()
                {
                    CustomerId = 321,
                    CustomerDemographicInfo = new Demographics()
                    {
                        DateOfBirth = new DateTime(1992, 5, 14),
                        Sex = PersonSex.Female
                    },
                    Information = new PersonalInformation()
                    {
                        FirstName = "Lisa",
                        LastName = "Bakster"
                    }
                }
            };
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return new Customer()
            {
                CustomerId = id,
                CustomerDemographicInfo = new Demographics()
                {
                    DateOfBirth = new DateTime(1982, 7, 24),
                    Sex = PersonSex.Male
                },
                Information = new PersonalInformation()
                {
                    FirstName = "Sam",
                    LastName = "Jones"
                }
            };
        }            
    }
}
