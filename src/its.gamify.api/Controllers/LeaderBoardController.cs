using its.gamify.core.Features.AvailablesData;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/leaderboard")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private Ultils data;
        public LeaderBoardController(Ultils data)
        {
            this.data = data;
        }
        /// <summary>
        /// Get all leader board
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 0,
                                        [FromQuery] int pageSize = 10,
                                        [FromQuery] string searchTerm = ""
                                        )
        {
            return Ok(data.leaderBoards);

        }
    }
}
