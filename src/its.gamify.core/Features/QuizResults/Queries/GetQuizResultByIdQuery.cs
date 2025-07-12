using its.gamify.api.Features.Quizzes.Queries;
using its.gamify.core;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.QuizResults.Queries
{
    public class GetQuizResultByIdQuery : IRequest<QuizResult>
    {
        public Guid Id { get; set; }
        class QueryHandler : IRequestHandler<GetQuizResultByIdQuery, QuizResult>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<QuizResult> Handle(GetQuizResultByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork.QuizResultRepository.FirstOrDefaultAsync(x => x.Id == request.Id, false, cancellationToken))
                     ?? throw new InvalidOperationException("Không tìm thấy Quiz result với id " + request.Id);
            }
        }
    }
}
