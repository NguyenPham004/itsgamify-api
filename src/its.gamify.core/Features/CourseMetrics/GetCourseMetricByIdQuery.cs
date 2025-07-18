using its.gamify.core;
using its.gamify.core.Features.CourseResults;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseMetrics
{
    public class GetCourseMetricByIdQuery : IRequest<CourseMetric>
    {
        public Guid Id { get; set; }
        public class QueryHandler : IRequestHandler<GetCourseMetricByIdQuery, CourseMetric>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<CourseMetric> Handle(GetCourseMetricByIdQuery request, CancellationToken cancellationToken)
            {
                return await unitOfWork.CourseMetricRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken) ?? throw new BadRequestException("");
            }
        }
    }
}
