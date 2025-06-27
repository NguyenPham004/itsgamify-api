using its.gamify.api.Features.Questions.Commands;
using its.gamify.api.Features.Questions.Queries;
using its.gamify.api.Features.QuizAnswers.Commands;
using its.gamify.api.Features.QuizAnswers.Queries;
using its.gamify.api.Features.Quizes.Commands;
using its.gamify.api.Features.Quizes.Queries;
using its.gamify.api.Features.QuizResults.Commands;
using its.gamify.api.Features.QuizResults.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace its.gamify.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IMediator mediator;
        public QuizzesController(IMediator mediator)
        {
            this.mediator = mediator;
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
        [HttpPut("{id}")]
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
        [HttpGet("{id}/questions")]
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
        [HttpPost("{id}/questions")]
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
        [HttpPut("{id}/questions")]
        public async Task<IActionResult> Update([FromForm] UpdateQuestionCommand updatedItem)
        {
            var result = await mediator.Send(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }
        /// <summary>
        /// Delete question
        /// </summary>
        [HttpDelete("{id}/question/{idQuestion}")]
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
        [HttpGet("{id}/quizzes")]
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
        /// Get all quiz result
        /// </summary>
        [HttpGet("{id}/quiz-results")]
        public async Task<IActionResult> GetAllQuizResult([FromQuery] int pageNumber = 0,
                                        [FromQuery] int pageSize = 10,
                                        [FromQuery] string searchTerm = ""
                                        )
        {
            var res = await mediator.Send(new GetAllQuizResultQuery()
            {
                PageIndex = pageNumber,
                PageSize = pageSize,
            });
            return Ok(res);

        }
        /// <summary>
        /// get quiz result by id
        /// </summary>
        [HttpGet("{id}/quiz-result/{idQuizResult}")]
        public async Task<IActionResult> GetQuizResultById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetQuizResultByIdQuery()
            {
                Id = id
            }));
        }
        /// <summary>
        /// Create quiz result
        /// </summary>
        [HttpPost("{id}/quiz-results")]
        public async Task<IActionResult> CreateQuizResult([FromForm] CreateQuizResultCommand command,
            [FromServices] IMediator mediator)
        {
            /*createcourseDTO.File = formFile;*/

            var result = await mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Update quiz reuslt
        /// </summary>
        [HttpPut("{id}/quiz-results")]
        public async Task<IActionResult> UpdateQuizResult([FromForm] UpdateQuizResultCommand updatedItem)
        {
            var result = await mediator.Send(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }
        /// <summary>
        /// Delete quiz result
        /// </summary>
        [HttpDelete("{id}/quiz-results/{idQuiz}")]
        public async Task<IActionResult> DeleteQuizResult(Guid id)
        {
            var res = await mediator.Send(new DeleteQuizResultCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }

        /// <summary>
        /// Get all quiz answer
        /// </summary>
        [HttpGet("{id}/quiz-answers")]
        public async Task<IActionResult> GetAllQuizAnswer([FromQuery] int pageNumber = 0,
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
        /// get quiz answer by id
        /// </summary>
        [HttpGet("{id}/quiz-answers/{idQuizResult}")]
        public async Task<IActionResult> GetQuizAnswerById([FromRoute] Guid id)
        {
            return Ok(await mediator.Send(new GetQuizAnswerByIdQuery()
            {
                Id = id
            }));
        }
        /// <summary>
        /// Create quiz answer
        /// </summary>
        [HttpPost("{id}/quiz-answers")]
        public async Task<IActionResult> CreateQuizAnswer([FromForm] CreateQuizAnswerCommand command,
            [FromServices] IMediator mediator)
        {
            /*createcourseDTO.File = formFile;*/

            var result = await mediator.Send(command);
            return Ok(result);
        }
        /// <summary>
        /// Update quiz answer
        /// </summary>
        [HttpPut("{id}/quiz-answers")]
        public async Task<IActionResult> UpdateQuizAnswer([FromForm] UpdateQuizAnswerCommand updatedItem)
        {
            var result = await mediator.Send(updatedItem);
            if (result) return NoContent();
            else return BadRequest();
        }
        /// <summary>
        /// Delete quiz answer
        /// </summary>
        [HttpDelete("{id}/quiz-answers/{idQuiz}")]
        public async Task<IActionResult> DeleteQuizAnswer(Guid id)
        {
            var res = await mediator.Send(new DeleteQuizAnswerCommand()
            {
                Id = id
            });
            return res ? NoContent() : StatusCode(500);
        }
    }
}

