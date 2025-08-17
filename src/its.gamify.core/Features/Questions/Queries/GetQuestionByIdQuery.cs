using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Questions.Queries
{
    public class GetQuestionByIdQuery : IRequest<Question>
    {
        public Guid Id { get; set; }
        class QueryHandler : IRequestHandler<GetQuestionByIdQuery, Question>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Question> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork.QuestionRepository.FirstOrDefaultAsync(x => x.Id == request.Id, false, cancellationToken,
                    [x => x.Quiz]))
                     ?? throw new InvalidOperationException("Không tìm thấy Question với id " + request.Id);
            }
        }
    }
}
