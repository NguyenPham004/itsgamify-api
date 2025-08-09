using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Challenges
{
    public class GetChallengeByIdQuery : IRequest<Challenge>
    {
        public Guid Id { get; set; }
        public class QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetChallengeByIdQuery, Challenge>
        {

            public async Task<Challenge> Handle(GetChallengeByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork
                    .ChallengeRepository
                    .GetByIdAsync(
                        request.Id,
                        cancellationToken: cancellationToken,
                        includes: [x => x.Course, x => x.Category!, x => x.Course.CourseResults.Where(x => x.UserId == claimsService.CurrentUser)]
                    )) ?? throw new InvalidOperationException("Thử thách không tồn tại");
            }
        }
    }
}
