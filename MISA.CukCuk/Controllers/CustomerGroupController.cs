using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    public class CustomerGroupController : MISAEntityControlle<CustomerGroup>
    {
        //ICustomerRepository _customerRepository;
        //ICustomerService _customerService;

        IBaseRepository<CustomerGroup> _customerRepository;
        IBaseService<CustomerGroup> _customerService;
        public CustomerGroupController(IBaseRepository<CustomerGroup> customerRepositoy,
            IBaseService<CustomerGroup> customerService) : base(customerRepositoy, customerService)
        {
            _customerRepository = customerRepositoy;
            _customerService = customerService;
        }
    }
}
