using its.gamify.core;
using its.gamify.core.Models.Departments;
using MediatR;

namespace its.gamify.api.Features.Departments.Commands
{
    public class UpdateDepartmentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public required DepartmentUpdateModel Model { get; set; }


        class CommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateDepartmentCommand, bool>
        {

            public async Task<bool> Handle(UpdateDepartmentCommand request,
                CancellationToken cancellationToken)
            {
                var updatedItem = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.Id) ??
                        throw new Exception("Không tìm thấy department!");

                _unitOfWork.Mapper.Map(request.Model, updatedItem);
                _unitOfWork.DepartmentRepository.Update(updatedItem);
                return await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
