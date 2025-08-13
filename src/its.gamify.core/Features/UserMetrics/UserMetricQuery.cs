using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;


namespace its.gamify.core.Features.UserMetrics;

public class UserMetricQuery : IRequest<UserMetric>
{
    public Guid Id { get; set; }
    public FilterQuery? Filter { get; set; }
    class QueryHandler(IUnitOfWork unitOfWork, ICurrentTime currentTime) : IRequestHandler<UserMetricQuery, UserMetric>
    {
        public async Task<UserMetric> Handle(UserMetricQuery request, CancellationToken cancellationToken)
        {

            var quarter = await unitOfWork.QuarterRepository
                .FirstOrDefaultAsync(q => q.StartDate <= currentTime.GetCurrentTime && q.EndDate >= currentTime.GetCurrentTime) ?? throw new BadRequestException("Không tìm thấy quý!");

            return await unitOfWork.UserMetricRepository.FirstOrDefaultAsync(x => x.UserId == request.Id && x.QuarterId == quarter.Id, cancellationToken: cancellationToken)
                ?? throw new NotFoundException("Không tìm thấy chỉ số người dùng!");
        }
    }

}