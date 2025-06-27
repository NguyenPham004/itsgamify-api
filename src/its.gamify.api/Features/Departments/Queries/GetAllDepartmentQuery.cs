using its.gamify.api.Features.Questions.Queries;
using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.api.Features.Departments.Queries
{
    public class GetAllDepartmentQuery : IRequest<BasePagingResponseModel<Department>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Search { get; set; } = string.Empty;
        class QueryHandler : IRequestHandler<GetAllDepartmentQuery, BasePagingResponseModel<Department>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<Department, bool>>? filter = null;
                if (!string.IsNullOrEmpty(request.Search))
                {
                    filter = x => x.Name.Contains(request.Search);
                }
                var res = await unitOfWork.DepartmentRepository.ToPagination(request.PageIndex, request.PageSize);

                return new BasePagingResponseModel<Department>(datas: res.Entities, pagination: res.Pagination);
            }

        }

    }
}
