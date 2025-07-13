using its.gamify.core;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Departments;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Departments.Commands
{
    public class CreateDepartmentCommand : IRequest<Department>
    {
        public required DepartmentCreateModel Model { get; set; }

        class CommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateDepartmentCommand, Department>
        {

            public async Task<Department> Handle(CreateDepartmentCommand request,
                CancellationToken cancellationToken)
            {
                var exist = await _unitOfWork.DepartmentRepository.WhereAsync(x => x.Name == request.Model.Name);
                if (exist.Count != 0) throw new BadRequestException("Phòng ban đã tồn tại");
                var createItem = _unitOfWork.Mapper.Map<Department>(request.Model.Name);
                await _unitOfWork.DepartmentRepository.AddAsync(createItem, cancellationToken);
                await _unitOfWork.SaveChangesAsync();
                return createItem;
            }
        }
    }
}
