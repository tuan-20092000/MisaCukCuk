using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Service
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <returns>số lượng bản ghi thêm mới được</returns>
        int? Insert(MISAEntity entity);

        /// <summary>
        /// update 1 bản ghi
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <param name="entityId">Id của thực thể</param>
        /// <returns>số lượng bản ghi update được</returns>
        int? Update(MISAEntity entity, Guid entityId);
    }
}
