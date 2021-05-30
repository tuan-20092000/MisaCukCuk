using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Ifarstructure
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        ///     Hàm paging
        /// </summary>
        /// <param name="pageIndex">vị trí trang</param>
        /// <param name="pageSize">số bản ghi/trang</param>
        /// <returns>danh sách khách hàng</returns>
        List<Customer> GetPaging(int? pageIndex = null, int? pageSize = null);

        /// <summary>
        ///     Hàm kiểm tra mã khách hàng thêm mới đã tồn tại hay chưa
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>true nếu không trùng, false nếu trùng</returns>
        bool CheckCustomerCode(string customerCode);

        /// <summary>
        ///     Hàm kiểm tra xem thông tin khách hàng được sửa có hợp lệ không
        /// </summary>
        /// <param name="customer">khách hàng</param>
        /// <returns>true nếu hợp lệ, false nếu không hợp lệ</returns>
        bool CheckCustomer(Customer customer);
    }
}
