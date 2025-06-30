using its.gamify.core;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseParticipations.Commands
{
    public class JoinCourseCommand : IRequest<CourseParticipation>
    {
        public class CommandHandler : IRequestHandler<JoinCourseCommand, CourseParticipation>
        {
            private readonly IClaimsService claimService;
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IClaimsService claimService,
                IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public Task<CourseParticipation> Handle(JoinCourseCommand request,
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
