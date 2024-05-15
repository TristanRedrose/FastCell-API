using FC_BAL.Services.Base.IBaseService;
using Microsoft.AspNetCore.Mvc;

namespace FastCell.Controllers.BaseController
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<TEntity> : ControllerBase where TEntity : class

    {
        protected readonly IBaseService<TEntity> _service;

        public BaseController(IBaseService<TEntity> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(TEntity entity)
        {
            
            var actionSuccess = await _service.AddAsync(entity);
            if (actionSuccess)
            {
                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync()
        {

            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TEntity>> GetByIdAsync([FromRoute] Guid id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null) {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var actionSuccess = await _service.DeleteAsync(id);

            if (actionSuccess)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult<TEntity>> UpsertAsync(TEntity entity)
        {
            var actionSucceess = await _service.UpsertAsync(entity);

            if (actionSucceess)
            {
                return Ok(entity);
            }

            return BadRequest();
        }
    }
    
}
