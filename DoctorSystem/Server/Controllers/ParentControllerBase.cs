using System.Threading.Tasks;
using DoctorSystem.Server.Adapter;
using DoctorSystem.Shared.Model;
using DoctorSystem.Shared.Model.Entity;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace DoctorSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ParentControllerBase<TEntity, TDto, TPrimaryKey> : ControllerBase where TEntity : class, IEntity<TPrimaryKey>
    {
        protected readonly EntityAdapter<TEntity, TPrimaryKey> _adapter;

        protected ParentControllerBase(IEntityAdapterFactory factory)
        {
            _adapter = factory.Get<TEntity, TPrimaryKey>();
        }

        protected virtual TEntity InsertOrUpdateAdaptationOverride(TDto dto)
        {
            return dto.Adapt<TEntity>();
        }

        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetByCheckUpId(TPrimaryKey id)
        {
            if (await _adapter.GetById(id) is TEntity result)
                return Ok(result.Adapt<TDto>());
            else
                return NotFound();
        }
        [HttpPost]
        [HttpPut]
        [HttpPatch]
        public async Task<IActionResult> InsertOrUpdateByCheckUpId([FromBody] TDto data)
        {
            var (result, entity, exception) = await _adapter.AddOrUpdateEntity(InsertOrUpdateAdaptationOverride(data));
            switch (result)
            {
                case AdapterOperationResult.Succeed: return Ok(entity.Adapt<TDto>());
                case AdapterOperationResult.Conflict: return Conflict(entity.Adapt<TDto>());
                case AdapterOperationResult.NotFound: return NotFound("This entity is not exist, yet.");
                case AdapterOperationResult.Error: return StatusCode(500, exception.Message);
                default: return StatusCode(500);
            }
        }

        [HttpDelete("id/{id:int}")]
        public async Task<IActionResult> DeleteByCheckUpId(int id)
        {
            var (result, exception) = await _adapter.DeleteById(id);
            if (result == AdapterOperationResult.Succeed) return Ok();
            else return StatusCode(500, exception.Message);
        }
    }
}