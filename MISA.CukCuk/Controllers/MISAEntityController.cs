using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Ifarstructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class MISAEntityControlle<MISAEntity> : ControllerBase
    {
        #region Declare
        IBaseRepository<MISAEntity> _baseRepository;
        IBaseService<MISAEntity> _baseService;
        #endregion

        #region Constructor
        public MISAEntityControlle(IBaseRepository<MISAEntity> baseRepository, IBaseService<MISAEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Methods
        // GET: api/<MISAEntityController>
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseRepository.GetAll();
            if (entities.Count > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{customerId}")]
        public IActionResult Get(Guid customerId)
        {
            var entity = _baseRepository.GetById(customerId);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var rowAffects = _baseService.Insert(entity);
            if (rowAffects > 0)
            {
                return Ok(rowAffects);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MISAEntity entity)
        {
            var rowAffect = _baseService.Update(entity, id);
            if (rowAffect > 0)
            {
                return Ok(rowAffect);
            }
            return BadRequest();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            var rowAffect = _baseRepository.Delete(customerId);
            if (rowAffect > 0)
            {
                return Ok(rowAffect);
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
