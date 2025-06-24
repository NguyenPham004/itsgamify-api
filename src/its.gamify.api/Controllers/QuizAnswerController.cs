using its.gamify.core.Features.AvailablesData;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/quiz-answers")]
    [ApiController]
    public class QuizAnswerController : ControllerBase
    {
        private Ultils data;
        public QuizAnswerController(Ultils data)
        {
            this.data = data;
        }
        /// <summary>
        /// Get all quiz answer
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 0,
                                        [FromQuery] int pageSize = 10,
                                        [FromQuery] string searchTerm = ""
                                        )
        {
            return Ok(data.quarters);

        }
    }
}
