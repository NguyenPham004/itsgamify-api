using its.gamify.api.Features.Questions.Queries;
using its.gamify.core;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Departments.Queries
{
    public class GetDepartmentByIdQuery : IRequest<Department>
    {
        public Guid Id { get; set; }
        class QueryHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork.DepartmentRepository.FirstOrDefaultAsync(x => x.Id == request.Id, false, cancellationToken))
                     ?? throw new InvalidOperationException("Không tìm thấy Department với id " + request.Id);
            }
        }
    }
}
