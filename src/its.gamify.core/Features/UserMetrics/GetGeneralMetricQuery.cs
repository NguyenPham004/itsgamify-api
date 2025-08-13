using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;


namespace its.gamify.core.Features.UserMetrics;

public class GeneralMetricInfor
{
    public UserMetric TopMetric { get; set; } = null!;
    public int NumOfPlayer { get; set; } = 0;
    public int MatchInDay { get; set; } = 0;
    public double AverageCorrect { get; set; }
}

public class GetGeneralMetricQuery : IRequest<GeneralMetricInfor>
{
    class QueryHandler(IUnitOfWork unitOfWork, ICurrentTime currentTime) : IRequestHandler<GetGeneralMetricQuery, GeneralMetricInfor>
    {
        public async Task<GeneralMetricInfor> Handle(GetGeneralMetricQuery request, CancellationToken cancellationToken)
        {

            var quarter = await unitOfWork.QuarterRepository
                .FirstOrDefaultAsync(q => q.StartDate <= currentTime.GetCurrentTime && q.EndDate >= currentTime.GetCurrentTime) ?? throw new BadRequestException("Không tìm thấy quý!");

            var metricInQuater = await unitOfWork.UserMetricRepository.WhereAsync(x => x.QuarterId == quarter.Id && !x.User.IsDeleted, includes: x => x.User);

            var topMetric = metricInQuater
                .OrderByDescending(m => m.PointInQuarter)
                .FirstOrDefault();

            var today = currentTime.GetCurrentTime.Date;

            // Đếm số trận đấu trong ngày hiện tại
            var matchesInDay = await unitOfWork.UserChallengeHistoryRepository.WhereAsync(
                m => m.CreatedDate.Date == today);

            var matchesInQuater = await unitOfWork.UserChallengeHistoryRepository.WhereAsync(
                m => m.CreatedDate.Date >= quarter.StartDate && m.CreatedDate.Date <= quarter.EndDate);

            return new GeneralMetricInfor
            {
                TopMetric = topMetric ?? new UserMetric(),
                NumOfPlayer = metricInQuater.Count,
                MatchInDay = matchesInDay.Count / 2,
                AverageCorrect = matchesInQuater.Count > 0 ? matchesInQuater.Average(m => m.AverageCorrect) : 0
            };
        }
    }

}