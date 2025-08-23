using Hangfire;
using its.gamify.core.Features.Notifications.Commands;
using its.gamify.core.Services.Interfaces;
using its.gamify.core.SingalR;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace its.gamify.core.Features.Badges.Commands;

public class CreateBadgeModel
{
    public required string Type { get; set; }
    public required Guid UserId { get; set; }
}

public class CreateBadgeCommand : IRequest
{

    public required CreateBadgeModel Model { get; set; }
    class CommandHandler(
        IUnitOfWork _unitOfWork,
        IBackgroundJobClient _backgroundJobClient,
        IMediator _mediator,
        ICurrentTime _currentTime
    ) : IRequestHandler<CreateBadgeCommand>
    {

        public async Task Handle(CreateBadgeCommand request, CancellationToken cancellationToken)
        {
            _backgroundJobClient.Enqueue(() => HandleCreateBadge(request.Model));
            await Task.Delay(1, cancellationToken);
        }


        public async Task HandleCreateBadge(CreateBadgeModel model)
        {
            var badge = await _unitOfWork
              .BadgeRepository
              .FirstOrDefaultAsync(x => x.UserId == model.UserId && x.Type == model.Type);
            if (badge != null) return;

            bool isValid = false;
            switch (model.Type)
            {
                case BadgeType.KNOWLEDGE_SEEKER:
                    isValid = await HandleKnowledgeSeeker(model);
                    break;
                case BadgeType.QUIZ_MASTER:
                    isValid = await HandleQuizMaster(model);
                    break;
                case BadgeType.SKILL_BUILDER:
                    isValid = await HandleSkillBuilder(model);
                    break;
                case BadgeType.OUTSTANDING_ACHIEVEMENT:
                    isValid = await HandleOutstandingAchievement(model);
                    break;
                case BadgeType.EXPLORER:
                    isValid = await HandleExplorer(model);
                    break;
                case BadgeType.CERTIFICATE_HUNTER:
                    isValid = await HandleCertificateHunter(model);
                    break;
                case BadgeType.FIRST_VICTORY:
                    isValid = await HandleFirstVictory(model);
                    break;
                case BadgeType.COMBO_MASTER:
                    isValid = await HandleComboMaster(model);
                    break;
                case BadgeType.INVINCIBLE:
                    isValid = await HandleInvincible(model);
                    break;
                case BadgeType.TOP_CHALLENGER:
                    isValid = await HandleTopChallenger(model);
                    break;
            }

            if (!isValid) return;

            await CreateBageAsync(model);

        }

        public async Task CreateBageAsync(CreateBadgeModel model)
        {
            var badge = new Badge
            {
                Title = BadgeType.GetTitleByType(model.Type),
                Description = BadgeType.GetDescriptionByType(model.Type),
                Type = model.Type,
                UserId = model.UserId
            };

            await _unitOfWork.BadgeRepository.AddAsync(badge);
            await _unitOfWork.SaveChangesAsync();

            await _mediator.Send(new CreateNotificationCommand()
            {
                Model = new NotificationCreateModel
                {
                    UserId = model.UserId,
                    Type = NotificationType.NEW_BADGE
                }
            });
        }

        public async Task<bool> HandleKnowledgeSeeker(CreateBadgeModel model)
        {
            var course_completed = await _unitOfWork
                .CourseParticipationRepository
                .WhereAsync(x => x.UserId == model.UserId && x.Status == COURSE_PARTICIPATION_STATUS.COMPLETED);

            if (course_completed.Count != 5) return false;

            return true;
        }

        public async Task<bool> HandleQuizMaster(CreateBadgeModel model)
        {
            var quiz_results = await _unitOfWork
                    .QuizResultRepository
                    .WhereAsync(x =>
                        x.Score == 10 && x.CreatedBy == model.UserId);

            if (quiz_results.Count != 1) return false;

            return true;
        }

        public async Task<bool> HandleSkillBuilder(CreateBadgeModel model)
        {
            var course_completed = await _unitOfWork
                .CourseParticipationRepository
                .WhereAsync(x => x.UserId == model.UserId && x.Status == COURSE_PARTICIPATION_STATUS.COMPLETED);

            if (course_completed.Count != 3) return false;
            return true;
        }

        public async Task<bool> HandleOutstandingAchievement(CreateBadgeModel model)
        {
            await Task.Delay(1);
            return false;

        }

        public async Task<bool> HandleExplorer(CreateBadgeModel model)
        {
            var course_participations = await _unitOfWork
                .CourseParticipationRepository
                .WhereAsync(x => x.UserId == model.UserId, includes: [x => x.Course]);

            var distinctCategories = course_participations
                .Where(cp => cp.Course != null)
                .Select(cp => cp.Course.CategoryId)
                .Distinct()
                .Count();

            return distinctCategories >= 3;
        }

        public async Task<bool> HandleCertificateHunter(CreateBadgeModel model)
        {

            var course_completed = await _unitOfWork
                .CourseParticipationRepository
                .WhereAsync(x => x.UserId == model.UserId && x.Status == COURSE_PARTICIPATION_STATUS.COMPLETED);

            if (course_completed.Count != 10) return false;
            return true;
        }

        public async Task<bool> HandleFirstVictory(CreateBadgeModel model)
        {
            var badge = await _unitOfWork
              .BadgeRepository
              .FirstOrDefaultAsync(x => x.UserId == model.UserId && x.Type == model.Type);
            if (badge != null) return false;

            var histories = await _unitOfWork
              .UserChallengeHistoryRepository
              .WhereAsync(x => x.UserId == model.UserId && x.Status == UserChallengeHistoryEnum.WIN);
            if (histories.Count != 1) return false;
            return true;
        }

        public async Task<bool> HandleComboMaster(CreateBadgeModel model)
        {

            var quarter = (await _unitOfWork.QuarterRepository
                .FirstOrDefaultAsync(q => q.StartDate <= _currentTime.GetCurrentTime && q.EndDate >= _currentTime.GetCurrentTime))
                ?? throw new Exception("No current quarter found");

            var metric = await _unitOfWork
                .UserMetricRepository
                .FirstOrDefaultAsync(x =>
                    x.UserId == model.UserId &&
                    x.QuarterId == quarter.Id
                ) ?? throw new Exception("No current metric found");

            if (metric.WinStreak != 3) return false;

            return true;
        }

        public async Task<bool> HandleInvincible(CreateBadgeModel model)
        {
            var quarter = (await _unitOfWork.QuarterRepository
               .FirstOrDefaultAsync(q => q.StartDate <= _currentTime.GetCurrentTime && q.EndDate >= _currentTime.GetCurrentTime))
               ?? throw new Exception("No current quarter found");

            var metric = await _unitOfWork
                .UserMetricRepository
                .FirstOrDefaultAsync(x =>
                    x.UserId == model.UserId &&
                    x.QuarterId == quarter.Id
                ) ?? throw new Exception("No current metric found");

            if (metric.WinStreak != 5) return false;

            return true;
        }

        public async Task<bool> HandleTopChallenger(CreateBadgeModel model)
        {
            await Task.Delay(1);
            return false;
        }
    }
}
