using its.gamify.core;
using MediatR;
namespace its.gamify.api.Features.Departments.Commands
{
    public class DeleteRangeDepartmentCommand : IRequest<bool>
    {
        public List<Guid> Ids { get; set; }= new List<Guid>();
        class CommandHandler : IRequestHandler<DeleteRangeDepartmentCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteRangeDepartmentCommand request, CancellationToken cancellationToken)
            {
                var listDepartment = await unitOfWork.DepartmentRepository.WhereAsync(p=>request.Ids.Contains(p.Id));
                //var question = await unitOfWork.DepartmentRepository.GetByIdAsync(request.Id);
                if (listDepartment.Count > 0)
                {
                    unitOfWork.DepartmentRepository.SoftRemoveRange(listDepartment);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Department not found");
            }
        }

    }
}
