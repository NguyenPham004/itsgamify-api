using its.gamify.core;
using its.gamify.core.Features.AvailablesData;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.api.Features.Users.Queries
{

    public class GetAllCourseQuery : IRequest<BasePagingResponseModel<Course>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Search { get; set; } = string.Empty;
        class QueryHandler : IRequestHandler<GetAllCourseQuery, BasePagingResponseModel<Course>>
        {
            private readonly IUnitOfWork unitOfWork;
            private Ultils data;
            public QueryHandler(IUnitOfWork unitOfWork, Ultils data)
            {
                this.unitOfWork = unitOfWork;
                this.data = data;
            }
            public async Task<BasePagingResponseModel<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<Course, bool>>? filter = null;
                if (!string.IsNullOrEmpty(request.Search))
                {
                    filter = x => x.Title.Contains(request.Search);
                }
                var res = await unitOfWork.CourseRepository.ToPagination(request.PageIndex, request.PageSize, filter: filter, includes: [x => x.Category!,
                 x => x.Quarter]);

                return new BasePagingResponseModel<Course>(datas: res.Entities, pagination: res.Pagination);
            }

        }

    }

}
