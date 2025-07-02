using its.gamify.api.Features.Practices.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{

    public class PracticesController : BaseController
    {
        private readonly IMediator mediator;
        public PracticesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Del([FromRoute] Guid id)
        {
            await mediator.Send(new DeletePracticeCommand()
            {
                Id = id
            });
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DelRange([FromRoute] List<Guid> ids)
        {
            foreach (var id in ids)
            {
                await mediator.Send(new DeletePracticeCommand()
                {
                    Id = id
                });
            }
            return NoContent();
        }
    }
}
