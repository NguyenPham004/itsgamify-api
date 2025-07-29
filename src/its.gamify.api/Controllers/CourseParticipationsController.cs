using its.gamify.core.Features.CourseParticipations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [ApiController]
    [Route("api/course-participations")]
    public class CourseParticipationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseParticipationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] ParticipationQuery participationQuery)
        {
            var result = await _mediator.Send(new GetCourseParticipationQuery()
            {
                ParticipationQuery = participationQuery
            });

            return Ok(result);
        }

    }
}
