using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Core.Interfaces.Infrastructure;

namespace MISA.Core.Services
{
    public class CustomerService :BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository) :base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override int? Insert(Customer customer)
        {
            var conflict = _customerRepository.CheckCustomerCode(customer.CustomerCode);
            if(conflict == false)
            {
                return 0;
            }
            return _customerRepository.Insert(customer);
        }

        
        public override int? Update(Customer customer, Guid customerId)
        {
            var isValid = _customerRepository.CheckCustomer(customer);
            if (isValid == false )
            {
                return 0;
            }
            return _customerRepository.Update(customer, customerId);
        }
        
    }
}
