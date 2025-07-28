using Hangfire;
using its.gamify.core;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Lessons;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;

namespace its.gamify.api.Features.LearningProgresses.Commands
{
    public class UpsertProgressCommand : LearningProgessUpsertModel, IRequest<LearningProgress>
    {
        public required LearningProgessUpsertModel Model { get; set; }

        class CommandHandler(
            IUnitOfWork _unitOfWork,
            IBackgroundJobClient _backgroundJobClient
        ) : IRequestHandler<UpsertProgressCommand, LearningProgress>
        {

            public async Task CompletedCourse(Guid participationId)
            {
                var participation = await _unitOfWork
                    .CourseParticipationRepository
                    .GetByIdAsync(participationId, includes: x => x.LearningProgresses.Where(x => !x.IsDeleted))
                ?? throw new BadRequestException("Chưa tham gia khóa học");

                var modules = await _unitOfWork
                    .CourseSectionRepository
                    .WhereAsync(x => x.CourseId == participation.CourseId, includes: x => x.Lessons.Where(x => !x.IsDeleted));

                int totalLessons = modules.Sum(module => module.Lessons.Count);
                int completedLesson = participation.LearningProgresses.Where(x => x.Status == PROGRESS_STATUS.COMPLETED).Count();
                if (totalLessons == completedLesson)
                {

                    var quarter = await _unitOfWork.QuarterRepository
                        .FirstOrDefaultAsync(q => q.StartDate <= DateTime.UtcNow && q.EndDate >= DateTime.UtcNow)
                        ?? throw new BadRequestException("No current quarter found");

                    var metric = await _unitOfWork
                        .UserMetricRepository
                        .FirstOrDefaultAsync(x => x.UserId == participation.UserId && x.QuarterId == quarter.Id) ?? throw new BadRequestException("No user metric found");

                    metric.CourseCompletedNum += 1;
                    metric.PointInQuarter += 1000;

                    participation.Status = COURSE_PARTICIPATION_STATUS.COMPLETED;
                    _unitOfWork.CourseParticipationRepository.Update(participation);


                    var course_result = new CourseResult
                    {
                        Scrore = 10,
                        IsPassed = true,
                        CompletedDate = DateTime.UtcNow,
                        CourseId = participation.CourseId,
                        UserId = participation.UserId,
                        CourseParticipationId = participation.Id
                    };

                    _unitOfWork.UserMetricRepository.Update(metric);
                    await _unitOfWork.CourseResultRepository.AddAsync(course_result);
                    await _unitOfWork.SaveChangesAsync();
                }
            }

            public async Task<LearningProgress> Handle(UpsertProgressCommand request, CancellationToken cancellationToken)
            {
                Lesson lesson = await _unitOfWork.LessonRepository.GetByIdAsync(request.Model.LessonId)
                                ?? throw new Exception("Can not find lesson");

                var progress = await _unitOfWork
                    .LearningProgressRepository
                    .FirstOrDefaultAsync(x =>
                        x.LessonId == lesson.Id &&
                        x.CourseParticipationId == request.Model.CourseParticipationId
                    );

                if (progress != null)
                {
                    progress.LastAccessed = DateTime.UtcNow;
                    progress.Status = request.Model.Status;
                    progress.VideoTimePosition = (int)request.Model.VideoTimePosition;

                    _unitOfWork.LearningProgressRepository.Update(progress);
                }
                else
                {
                    progress = new LearningProgress
                    {
                        LessonId = lesson.Id,
                        LastAccessed = DateTime.UtcNow,
                        Status = request.Model.Status,
                        CourseParticipationId = request.Model.CourseParticipationId,
                        VideoTimePosition = (int)request.Model.VideoTimePosition
                    };
                    await _unitOfWork.LearningProgressRepository.AddAsync(progress, cancellationToken);
                }

                await _unitOfWork.SaveChangesAsync();
                _backgroundJobClient.Enqueue(() => CompletedCourse(request.Model.CourseParticipationId!));
                return progress;

            }

        }
    }
}