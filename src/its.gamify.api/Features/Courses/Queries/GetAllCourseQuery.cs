using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.api.Features.Users.Queries
{

    public class GetAllCourseQuery : IRequest<BasePagingResponseModel<Course>>
    {
        public FilterQuery? filterQuery { get; set; }

        class QueryHandler : IRequestHandler<GetAllCourseQuery, BasePagingResponseModel<Course>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
            {
                var res = await unitOfWork.CourseRepository.ToDynamicPagination(request.filterQuery?.Page ?? 0,
                    request.filterQuery?.Limit ?? 10,
                    searchTerm: request.filterQuery?.Q, searchFields: ["Title", "Description", "LongDescription"],
                    sortOrders: request.filterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                    includeFunc: x => x.Include(x => x.CourseSections)
                        .ThenInclude(x => x.Lessons)
                        .Include(x => x.LearningMaterials)
                            .ThenInclude(x => x.File)
                        .Include(x => x.Deparment!)
                        .Include(x => x.Category));
                return new BasePagingResponseModel<Course>(datas: res.Entities, pagination: res.Pagination);
            }

        }

    }

}
