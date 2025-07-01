using its.gamify.core;
using its.gamify.domains.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace its.gamify.api.Features.CourseCollections.Queries
{
    public class GetCourseCollectionByIdQuery : IRequest<CourseCollection>
    {
        public Guid Id { get; set; }
        public class QueryHandler : IRequestHandler<GetCourseCollectionByIdQuery, CourseCollection>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<CourseCollection> Handle(GetCourseCollectionByIdQuery request, CancellationToken cancellationToken)
            {
                return await unitOfWork.CourseCollectionRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
            }
        }
    }
}
