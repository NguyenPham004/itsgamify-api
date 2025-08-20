using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
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
                bool checkRole = claimsService.CurrentRole == ROLE.ADMIN || claimsService.CurrentRole == ROLE.TRAININGSTAFF ||
                claimsService.CurrentRole == ROLE.MANAGER;
                return (await unitOfWork
                    .ChallengeRepository
                    .FirstOrDefaultAsync(
                        x => !x.Course.IsDeleted && x.Course.Status == COURSE_STATUS.PUBLISHED && x.Course.IsDraft == false,
                        checkRole,
                        cancellationToken: cancellationToken,
                        includes: [x => x.Course, x => x.Category!, x => x.Course.CourseResults.Where(x => x.UserId == claimsService.CurrentUser)]
                    )) ?? throw new InvalidOperationException("Thử thách không tồn tại");
            }
        }
    }
}
