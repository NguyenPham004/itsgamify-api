using Firebase.Auth;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace its.gamify.core.Features.UserMetrics;

public class UserMetricQuery : IRequest<BasePagingResponseModel<UserMetric>>
{
    //public FilterQuery? Filter { get; set; }
    class QueryHandler (IUnitOfWork unitOfWork, IClaimsService _claimSerivce) : IRequestHandler<UserMetricQuery, BasePagingResponseModel<UserMetric>>
    {
        public async Task<BasePagingResponseModel<UserMetric>> Handle(UserMetricQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<UserMetric, bool>>? filter = null;
            var user = await unitOfWork.UserRepository.GetByIdAsync(_claimSerivce.CurrentUser) ?? throw new BadRequestException("Không tìm thấy người dùng!");
            var collections = (await unitOfWork.CourseCollectionRepository.WhereAsync(x => x.UserId == user.Id)).Select(x=>x.UserId).ToList();
            var targetDate = DateTime.Today;

            var quarterId = (await unitOfWork.QuarterRepository
                .WhereAsync(q => q.StartDate <= targetDate && q.EndDate >= targetDate))
                .Select(q => q.Id)
                .FirstOrDefault();
            filter = x => collections != null && collections.Count != 0 && collections.Contains(user.Id) && x.QuarterId == quarterId;
            Func<IQueryable<UserMetric>, IIncludableQueryable<UserMetric, object>>? includeFunc =
                x => x
                    .Include(x => x.User!)
                    .Include(x => x.Quarter);
            (Pagination Pagination, List<UserMetric> Entities)? res = null;
            res = await unitOfWork.UserMetricRepository.ToDynamicPagination(
                                0,
                                10,
                              filter: filter,
                              includeFunc: includeFunc
                        );
            return new BasePagingResponseModel<UserMetric>(datas: res.Value.Entities, pagination: res.Value.Pagination);
        }
    }

}