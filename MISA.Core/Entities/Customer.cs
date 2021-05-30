using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string CustomerCode { get; set; }

        public string FullName { get; set; }

        public int Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

    }
}
