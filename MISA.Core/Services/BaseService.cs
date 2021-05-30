using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual int? Insert(MISAEntity entity)
        {
            return _baseRepository.Insert(entity);
        }

        public virtual int? Update(MISAEntity entity, Guid entityId)
        {
            return _baseRepository.Update(entity, entityId);
        }
    }
}
