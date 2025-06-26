
using its.gamify.api.Features.DifficultyLevels.Commands;
using its.gamify.api.Features.DifficultyLevels.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{

    [Route("api/difficulty-levels")]
    public class DifficultyLevelController : BaseController
    {
        private readonly IMediator mediator;
        public DifficultyLevelController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 10)
        {

            var result = await mediator.Send(new GetAllDifficultyQuery()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            });
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDifficulty command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
