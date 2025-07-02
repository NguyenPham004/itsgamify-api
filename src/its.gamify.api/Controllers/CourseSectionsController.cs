using its.gamify.api.Features.CourseSections.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/course-sections")]
    public class CourseSectionsController : BaseController
    {
        private readonly IMediator mediator;
        public CourseSectionsController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelById([FromRoute] Guid id)
        {
            var res = await mediator.Send(new DeleteCourseSectionByIdCommand()
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
                var res = await mediator.Send(new DeleteCourseSectionByIdCommand()
                {
                    Id = id
                });
            }
            return NoContent();
        }
    }
}
