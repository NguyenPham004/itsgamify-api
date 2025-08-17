
using its.gamify.core.Features.UserMetrics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{

    public class MetricsController(IMediator mediator) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserMetricFilterQuery query)
        {

            var res = await mediator.Send(new GetAllUserMetricsQuery()
            {
                Filter = query
            });
            return Ok(res);
        }
        [HttpGet("general-infor")]
        public async Task<IActionResult> GetGeneralInfor()
        {

            var res = await mediator.Send(new GetGeneralMetricQuery());
            return Ok(res);
        }

        [HttpGet("top-10")]
        public async Task<IActionResult> GetTop10All([FromQuery] UserMetricFilterQuery query)
        {

            var res = await mediator.Send(new GetTop10UserMetricQuery()
            {
                Filter = query
            });
            return Ok(res);
        }

    }
}
