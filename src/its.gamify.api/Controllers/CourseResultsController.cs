using its.gamify.core.Features.CourseResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/course-results")]
    public class CourseResultsController(IMediator _mediator) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCourseResultByIdQuery { Id = id });
            if (result == null)
                throw new InvalidOperationException($"Không tìm thấy CourseResult với id: {id}");
            return Ok(result);
        }
    }
}
