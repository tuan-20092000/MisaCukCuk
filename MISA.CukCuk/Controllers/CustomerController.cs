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
    public class CustomerController : MISAEntityControlle<Customer>
    {
        ICustomerRepository _customerRepository;
        ICustomerService _customerService;

        //IBaseRepository<Customer> _customerRepository;
        //IBaseService<Customer> _customerService;
        public CustomerController(ICustomerRepository customerRepositoy,
            ICustomerService customerService) :base(customerRepositoy, customerService)
        {
            _customerRepository = customerRepositoy;
            _customerService = customerService;
        }

        [HttpGet("Paging")]

        public IActionResult GetPaging (int pageIndex, int pageSize)
        {
            var customers = _customerRepository.GetPaging(pageIndex, pageSize);
            if(customers.Count > 0)
            {
                return Ok(customers);
            }
            return NoContent();
        }
    }

   
}
