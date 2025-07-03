using its.gamify.api.Features.LearningMaterials.Commands;
using its.gamify.core.Features.LearningMaterials.Queries;
using its.gamify.core.Models.LearningMaterials;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/learning-materials")]
    public class LearningMaterialsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LearningMaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LearningMaterialCreateModel model,
                  [FromServices] IMediator mediator)
        {
            var res = await mediator.Send(new CreateLearningMaterialCommand()
            {
                Model = model,
            });

            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetLearningMaterialQuery query)
        {
            var result = await _mediator.Send(query);
            if (result == null || result.Datas == null || !result.Datas.Any())
                throw new InvalidOperationException("Danh sách LearningMaterial trống");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetLearningMaterialByIdQuery { Id = id });
            if (result == null)
                throw new InvalidOperationException($"Không tìm thấy LearningMaterial với id: {id}");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Del([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteLearningMaterialCommand()
            {
                Id = id
            });
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DelRange([FromQuery] List<Guid> ids)
        {
            foreach (var id in ids)
            {
                await _mediator.Send(new DeleteLearningMaterialCommand { Id = id });
            }
            return NoContent();
        }
    }
}
