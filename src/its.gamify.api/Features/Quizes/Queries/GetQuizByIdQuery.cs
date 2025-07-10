using its.gamify.api.Features.Questions.Queries;
using its.gamify.core;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Quizes.Queries
{
    public class GetQuizByIdQuery : IRequest<Quiz>
    {
        public Guid Id { get; set; }
        class QueryHandler : IRequestHandler<GetQuizByIdQuery, Quiz>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Quiz> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork.QuizRepository.FirstOrDefaultAsync(x => x.Id == request.Id, false, cancellationToken))
                     ?? throw new InvalidOperationException("Không tìm thấy Quiz với id " + request.Id);
            }
        }
    }
}
