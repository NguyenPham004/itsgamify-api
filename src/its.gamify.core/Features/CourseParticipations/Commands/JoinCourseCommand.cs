using Hangfire;
using its.gamify.core;
using its.gamify.core.Features.Badges.Commands;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
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
        public class CommandHandler(
            IClaimsService claimService,
            IUnitOfWork unitOfWork,
            ICurrentTime currentTime,
            IBackgroundJobClient _backgroundJobClient,
            IMediator _mediator
        ) : IRequestHandler<JoinCourseCommand, CourseParticipation>
        {

            public async Task UpdateUserMetric(Guid userId, Guid quarterId)
            {
                var metric = await unitOfWork
                    .UserMetricRepository
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.QuarterId == quarterId)
                    ?? throw new Exception("No user metric found");

                metric.CourseParticipatedNum += 1;
                unitOfWork.UserMetricRepository.Update(metric);
            }

            public async Task<CourseParticipation> Handle(JoinCourseCommand request,
                CancellationToken cancellationToken)
            {
                var currentUser = await unitOfWork.UserRepository.FirstOrDefaultAsync(x => x.Id == claimService.CurrentUser,
                    includeFunc: x => x.Include(x => x.Role)
                        .Include(x => x.Department!)) ?? throw new BadRequestException($"Không tìm thấy người dùng hiện tại Id: " + claimService.CurrentUser);

                var course = await unitOfWork.CourseRepository.FirstOrDefaultAsync(x => x.Id == request.Id && x.Status == COURSE_STATUS.PUBLISHED && !x.IsDraft)
                    ?? throw new BadRequestException($"Không tìm thấy khoá học với Id: {request.Id}");


                switch (course.CourseType)
                {
                    case COURSE_TYPE.DEPARTMENTONLY:
                        var checkCourse = await unitOfWork.CourseDepartmentRepository.FirstOrDefaultAsync(x => x.CourseId == course.Id && x.DepartmentId == currentUser.DepartmentId)
                            ?? throw new BadRequestException("Khoá học không nằm trong phòng ban của người dùng hiện tại");
                        break;
                    case COURSE_TYPE.LEADERONLY:
                        if (currentUser.Role?.Name != RoleEnum.LEADER.ToString())
                        {
                            throw new BadRequestException("Chỉ trưởng phòng mới được tham gia khoá học");
                        }
                        break;
                }

                var quarter = (await unitOfWork.QuarterRepository
                    .FirstOrDefaultAsync(q => q.StartDate <= currentTime.GetCurrentTime && q.EndDate >= currentTime.GetCurrentTime))
                    ?? throw new Exception("No current quarter found");

                var metric = await unitOfWork
                        .UserMetricRepository
                        .FirstOrDefaultAsync(x => x.UserId == currentUser.Id && x.QuarterId == quarter.Id)
                        ?? throw new Exception("No user metric found");

                if (metric.CourseParticipatedNum >= 5)
                    throw new BadRequestException("Đã đạt mức giới hạn cho phép trong 1 quý!");

                if (quarter.Id != course.QuarterId)
                    throw new BadRequestException("Bạn không thể tham gia khoá học!");

                var isDup = await unitOfWork.CourseParticipationRepository.FirstOrDefaultAsync(x => x.UserId == currentUser.Id && x.CourseId == course.Id);
                if (isDup is not null) throw new BadRequestException("Người dùng đã tham gia khoá học này rồi!");

                var courseParticipation = new CourseParticipation()
                {
                    CourseId = course.Id,
                    UserId = currentUser.Id,
                    Status = CourseParticipationStatusEnum.ENROLLED.ToString(),
                    EnrolledDate = currentTime.GetCurrentTime,
                    Deadline = quarter.EndDate!.Value,

                };
                metric.CourseParticipatedNum += 1;

                unitOfWork.UserMetricRepository.Update(metric);

                await unitOfWork.CourseParticipationRepository.AddAsync(courseParticipation, cancellationToken);
                await unitOfWork.SaveChangesAsync();

                _backgroundJobClient.Enqueue(() => UpdateUserMetric(currentUser.Id, quarter.Id));

                await _mediator.Send(new CreateBadgeCommand()
                {
                    Model = new CreateBadgeModel { Type = BadgeType.EXPLORER, UserId = currentUser.Id }
                }, cancellationToken);

                return courseParticipation;
            }
        }
    }
}
