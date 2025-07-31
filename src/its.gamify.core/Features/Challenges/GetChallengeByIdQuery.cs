using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Challenges
{
    public class GetChallengeByIdQuery : IRequest<Challenge>
    {
        public Guid Id { get; set; }
        public class QueryHandler : IRequestHandler<GetChallengeByIdQuery, Challenge>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Challenge> Handle(GetChallengeByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork
                    .ChallengeRepository
                    .GetByIdAsync(
                        request.Id,
                        cancellationToken: cancellationToken,
                        includes: [x => x.Course, x => x.Category!]
                    )) ?? throw new InvalidOperationException("Thử thách không tồn tại");
            }
        }
    }
}
