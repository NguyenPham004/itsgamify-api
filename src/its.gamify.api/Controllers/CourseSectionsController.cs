using its.gamify.api.Features.CourseSections.Commands;
using its.gamify.core.Models.CourseSections;
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

        [HttpPost]
        public async Task<IActionResult> CreateCourseSection([FromBody] CreateCourseSectionCommand command,
        [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseSection([FromRoute] Guid id, [FromBody] CourseSectionUpdateModel model)
        {
            var result = await mediator.Send(new UpsertCourseSectionCommand
            {
                SectionId = id,
                Model = model
            });
            return Ok(result);
        }

    }
}
