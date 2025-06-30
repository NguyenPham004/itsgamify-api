using its.gamify.core;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.api.Features.CourseParticipations.Commands
{
    public class JoinCourseCommand : IRequest<CourseParticipation>
    {
        public Guid Id { get; set; }
        public class CommandHandler : IRequestHandler<JoinCourseCommand, CourseParticipation>
        {

            private readonly IClaimsService claimService;
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IClaimsService claimService,
                IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
                this.claimService = claimService;
            }
            public async Task<CourseParticipation> Handle(JoinCourseCommand request,
                CancellationToken cancellationToken)
            {
                var currentUser = await unitOfWork.UserRepository.FirstOrDefaultAsync(x => x.Id == claimService.CurrentUser,
                    includeFunc: x => x.Include(x => x.Role)
                        .Include(x => x.Department!));
                var course = await unitOfWork.CourseRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (course is null) throw new InvalidOperationException($"Không tìm thấy khoá học với Id: {request.Id}");
                if (currentUser is null) throw new InvalidOperationException($"Không tìm thấy người dùng hiện tại Id: " + claimService.CurrentUser);

                if (course.Status != CourseStatusEnum.PUBLISHED.ToString() || course.IsDraft)
                    throw new InvalidOperationException("Khoá học chưa được publish hoặc khoá học là bản nháp! Không thể đăng ký");
                var courseParticipation = new CourseParticipation()
                {
                    CourseId = course.Id,
                    UserId = currentUser.Id,
                    Status = CourseParticipationStatusEnum.ENROLLED.ToString()
                };
                switch (course.CourseType)
                {
                    case nameof(CourseTypeEnum.DEPARTMENTONLY):
                        // Check exist in Dept
                        if (course.DepartmentId != currentUser.DepartmentId)
                        {
                            throw new Exception("Khoá học không nằm trong phòng ban của người dùng hiện tại");
                        }
                        else
                            break;
                    case nameof(CourseTypeEnum.LEADERONLY):
                        // check role is leader
                        if (currentUser.Role?.Name != RoleEnum.LEADER.ToString())
                        {
                            throw new InvalidOperationException("Chỉ LEADER mới được tham gia khoá học");
                        }
                        else
                            break;
                }
                await unitOfWork.CourseParticipationRepository.AddAsync(courseParticipation);
                await unitOfWork.SaveChangesAsync();
                return courseParticipation;
            }
        }
    }
}
