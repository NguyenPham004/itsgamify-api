using its.gamify.core;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                return (await unitOfWork.DepartmentRepository.FirstOrDefaultAsync(x => x.Id == request.Id, false, cancellationToken,
                    includeFunc: x => x.Include(x => x.Courses)
                        .Include(x => x.Users!)
                            .ThenInclude(x => x.Role!)))
                     ?? throw new InvalidOperationException("Không tìm thấy Department với id " + request.Id);
            }
        }
    }
}
