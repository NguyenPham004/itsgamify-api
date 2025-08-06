using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.core.Features.Questions.Queries;

public class QuestionFilterQuery : FilterQuery
{
    public Guid CourseId { get; set; }
}

public class GetAllQuestionQuery : IRequest<List<Question>>
{

    public required QuestionFilterQuery FilterQuery { get; set; }

    class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllQuestionQuery, List<Question>>
    {

        public async Task<List<Question>> Handle(GetAllQuestionQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<Question, bool>>? filter = x => x.CourseId == request.FilterQuery.CourseId;

            var allQuestions = await unitOfWork.QuestionRepository.WhereAsync(filter: filter);
            var limit = request.FilterQuery.Limit ?? 10;

            var randomQuestions = allQuestions
                .OrderBy(_ => Guid.NewGuid())
                .Take(Math.Min(limit, allQuestions.Count))
                .ToList();

            return randomQuestions;
        }
    }

}

