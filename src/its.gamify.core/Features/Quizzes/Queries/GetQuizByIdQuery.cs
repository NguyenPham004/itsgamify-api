using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Quizzes.Queries
{
    public class GetQuizByIdQuery : IRequest<Quiz>
    {
        public Guid Id { get; set; }
        class QueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetQuizByIdQuery, Quiz>
        {

            public async Task<Quiz> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _unitOfWork.QuizRepository
                    .FirstOrDefaultAsync(x =>
                        x.Id == request.Id, false,
                        cancellationToken,
                        includes: x => x.Questions.Where(x => !x.IsDeleted)
                    )
                ) ?? throw new InvalidOperationException("Không tìm thấy Quiz với id " + request.Id);
            }
        }
    }
}
