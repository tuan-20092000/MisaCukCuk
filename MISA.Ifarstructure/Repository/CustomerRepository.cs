using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace MISA.Ifarstructure.Repository
{
    public class CustomerRepository :BaseRepository<Customer> ,ICustomerRepository
    {
        public bool CheckCustomer(Customer customer)
        {
            var sqlQuery = $"Select * from Customer where CustomerCode = '{customer.CustomerCode}' " +
                $"and CustomerId != '{customer.CustomerId}' ";
            var res = DbConnection.Query<Customer>(sqlQuery).FirstOrDefault();
            if (res != null)
            {
                return false;
            }
            return true;
        }

        public bool CheckCustomerCode(string customerCode)
        {
            var sqlQuery = $"Select * from Customer c where c.CustomerCode = '{customerCode}'";
            var customers = DbConnection.Query<Customer>(sqlQuery).FirstOrDefault();
            if (customers != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Customer> GetPaging(int? pageIndex = null, int? pageSize = null)
        {
            var sqlCommand = $"Select * from Customer LIMIT @PageSize,@PageIndex";
            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("@PageSize", pageSize);
            dynamic.Add("@PageIndex", pageIndex);
            var customers = DbConnection.Query<Customer>(sqlCommand, dynamic).ToList();
            return customers;
        }
    }
}
