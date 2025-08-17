using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.QuizAnswers.Queries
{
    public class GetQuizAnswerByIdQuery : IRequest<QuizAnswer>
    {
        public Guid Id { get; set; }
        class QueryHandler : IRequestHandler<GetQuizAnswerByIdQuery, QuizAnswer>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<QuizAnswer> Handle(GetQuizAnswerByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork.QuizAnswerRepository.FirstOrDefaultAsync(x => x.Id == request.Id, false, cancellationToken,
                    [x => x.QuizResult, x => x.Question]))
                     ?? throw new InvalidOperationException("Không tìm thấy Quiz answer với id " + request.Id);
            }
        }
    }
}
