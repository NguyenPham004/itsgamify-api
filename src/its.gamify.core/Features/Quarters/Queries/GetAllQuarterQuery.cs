using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.api.Features.Quarters.Queries
{
    public class GetAllQuarterQuery : IRequest<BasePagingResponseModel<Quarter>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
        class QueuryHandler : IRequestHandler<GetAllQuarterQuery, BasePagingResponseModel<Quarter>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueuryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;

            }
            public async Task<BasePagingResponseModel<Quarter>> Handle(GetAllQuarterQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<Quarter, bool>>? filter = null;
                if (request.DateFrom is not null)
                {

                    if (request.DateTo is not null)
                    {
                        filter = x => x.StartDate >= request.DateFrom && x.EndDate <= request.DateTo;
                    }
                    else
                    {
                        filter = x => x.StartDate >= request.DateFrom;
                    }
                }
                if (request.DateTo is not null)
                {
                    filter = x => x.EndDate <= request.DateTo;
                }
                if (!string.IsNullOrEmpty(request.SearchTerm))
                {
                    filter = filter?.AndAlso(x => x.Name == request.SearchTerm);
                }


                var result = await unitOfWork.QuarterRepository.ToPagination(request.PageIndex, request.PageSize, false, filter);
                return new BasePagingResponseModel<Quarter>(result.Entities, result.Pagination);
            }
        }
    }
}
