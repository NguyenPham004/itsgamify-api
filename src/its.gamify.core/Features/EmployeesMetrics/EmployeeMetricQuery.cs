using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.core.Features.EmployeeMetrics;

public class EmployeeMetricQuery : IRequest<EmployeeMetric>
{
    public FilterQuery? Filter { get; set; }
    class QueryHandler : IRequestHandler<EmployeeMetricQuery, EmployeeMetric>
    {
        private readonly IUnitOfWork unitOfWork;
        public QueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<EmployeeMetric> Handle(EmployeeMetricQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Course, bool>>? filter = null;
            filter =x=>x.CourseParticipations.Any();
            //var courseResult = await unitOfWork.CourseRepository.ToDynamicPagination
            return new EmployeeMetric();
        }
    }

}