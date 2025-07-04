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
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetCourseParticipationQuery());
            if (result == null || result.Datas == null || result.Datas.Count == 0)
                return Ok();
            // throw new InvalidOperationException("Danh sách CourseParticipation trống");
            return Ok(result);
        }


    }
}
