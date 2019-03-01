using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersManagement.MS.Models
{
    public enum PersonSex
    {
        Male,
        Female,
        Unknown
    }

    public class Demographics
    {
        public PersonSex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
