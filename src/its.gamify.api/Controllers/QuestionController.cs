using its.gamify.api.Features.Courses.Commands;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.api.Features.Questions.Queries;
using its.gamify.api.Features.QuizAnswers.Queries;
using its.gamify.api.Features.Quizes.Commands;
using its.gamify.api.Features.Quizes.Queries;
using its.gamify.api.Features.Users.Commands;
using its.gamify.api.Features.Users.Queries;
using its.gamify.core.Features.AvailablesData;
using its.gamify.core.Models.Courses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator mediator;
        private Ultils data;
        public QuestionController(Ultils data, IMediator mediator)
        {
            this.data = data;
            this.mediator = mediator;
        }
        /// <summary>
        /// Get all question
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 0,
                                        [FromQuery] int pageSize = 10,
                                        [FromQuery] string searchTerm = ""
                                        )
        {
            var res = await mediator.Send(new GetAllQuestionQuery()
            {
                PageIndex = pageNumber,
                PageSize = pageSize,
            });
            return Ok(res);

        }
        /// <summary>
        /// get question by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetQuestionByIdQuery()
            {
                Id = id
            }));
        }
        /// <summary>
        /// Create question
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateQuestionCommand command,
            [FromServices] IMediator mediator)
        {
            /*createcourseDTO.File = formFile;*/

            var result = await mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Update question
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateQuestionCommand updatedItem)
        {
            var result = await mediator.Send(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }
        /// <summary>
        /// Delete question
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await mediator.Send(new DeleteQuestionCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
        /// <summary>
        /// Get all quiz
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllQuiz([FromQuery] int pageNumber = 0,
                                        [FromQuery] int pageSize = 10,
                                        [FromQuery] string searchTerm = ""
                                        )
        {
            var res = await mediator.Send(new GetAllQuizQuery()
            {
                PageIndex = pageNumber,
                PageSize = pageSize,
            });
            return Ok(res);

        }
        /// <summary>
        /// get quiz by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetQuizByIdQuery()
            {
                Id = id
            }));
        }
        /// <summary>
        /// Create quiz
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromForm] CreateQuizCommand command,
            [FromServices] IMediator mediator)
        {
            /*createcourseDTO.File = formFile;*/

            var result = await mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Update quiz
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateQuiz([FromForm] UpdateQuizCommand updatedItem)
        {
            var result = await mediator.Send(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }
        /// <summary>
        /// Delete quiz
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var res = await mediator.Send(new DeleteQuizCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
        /// <summary>
        /// Get all quiz result
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllQuizResult([FromQuery] int pageNumber = 0,
                                        [FromQuery] int pageSize = 10,
                                        [FromQuery] string searchTerm = ""
                                        )
        {
            var res = await mediator.Send(new GetAllQuizAnswerQuery()
            {
                PageIndex = pageNumber,
                PageSize = pageSize,
            });
            return Ok(res);

        }
        /// <summary>
        /// get quiz result by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetQuizByIdQuery()
            {
                Id = id
            }));
        }
        /// <summary>
        /// Create quiz
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromForm] CreateQuizCommand command,
            [FromServices] IMediator mediator)
        {
            /*createcourseDTO.File = formFile;*/

            var result = await mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Update quiz
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateQuiz([FromForm] UpdateQuizCommand updatedItem)
        {
            var result = await mediator.Send(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }
        /// <summary>
        /// Delete quiz
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var res = await mediator.Send(new DeleteQuizCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
    }
}
