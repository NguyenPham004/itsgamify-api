using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.core.Features.LearningMaterials.Queries
{
    public class GetLearningMaterialQuery : IRequest<BasePagingResponseModel<LearningMaterial>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid CourseId { get; set; }
        public class QueryHandler : IRequestHandler<GetLearningMaterialQuery, BasePagingResponseModel<LearningMaterial>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<LearningMaterial>> Handle(GetLearningMaterialQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<LearningMaterial, bool>>? filter = null;
                if (request.CourseId != Guid.Empty)
                {
                    filter = x => x.CourseId == request.CourseId;
                }
                var items = await unitOfWork.LearningMaterialRepository.ToPagination(
                    pageIndex: request.PageIndex,
                    filter: filter,
                    pageSize: request.PageSize,
                    includes: x => x.Course,
                    cancellationToken: cancellationToken);
                return new BasePagingResponseModel<LearningMaterial>(items.Entities, items.Pagination);
            }
        }
    }
}
