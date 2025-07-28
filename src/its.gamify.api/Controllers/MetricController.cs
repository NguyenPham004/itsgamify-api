
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

    }
}
