using CustomersManagement.MS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersManagement.MS.Views
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public PersonalInformation Information { get; set; }

        public Demographics CustomerDemographicInfo { get; set; }
    }
}
