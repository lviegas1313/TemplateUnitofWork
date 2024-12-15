using Microsoft.AspNetCore.Mvc;
using TemplateUnitofWork.Repositories;
using TemplateUnitofWork.Repository;

namespace TemplateUnitofWork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YourEntityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<YourEntityController> _logger;

        public YourEntityController(IUnitOfWork unitOfWork, ILogger<YourEntityController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting all entities");

            var entities = await _unitOfWork.YourEntities.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Getting entity with ID: {EntityId}", id);

            var entity = await _unitOfWork.YourEntities.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] YourEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Adding a new entity");

            await _unitOfWork.YourEntities.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] YourEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEntity = await _unitOfWork.YourEntities.GetByIdAsync(id);
            if (existingEntity == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Updating entity with ID: {EntityId}", id);

            _unitOfWork.YourEntities.Update(entity);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.YourEntities.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _logger.LogInformation("Deleting entity with ID: {EntityId}", id);

            _unitOfWork.YourEntities.Remove(entity);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }



}
