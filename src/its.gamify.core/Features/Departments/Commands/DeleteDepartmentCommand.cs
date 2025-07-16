using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.Departments.Commands
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        class CommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteDepartmentCommand, bool>
        {

            public async Task<bool> Handle(DeleteDepartmentCommand request,
                CancellationToken cancellationToken)
            {
                var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.Id) ??
                        throw new Exception("Không tìm thấy department!");

                _unitOfWork.DepartmentRepository.SoftRemove(department);

                return await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
