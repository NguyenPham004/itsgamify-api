using its.gamify.core.Features.Challenges.Commands;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Rooms.Commands
{
    public class DeleteRoomCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRoomCommand, bool>
        {

            public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
            {
                var room = await unitOfWork.RoomRepository.GetByIdAsync(request.Id) ?? throw new BadRequestException("Phòng không tồn tại!");

                unitOfWork.RoomRepository.SoftRemove(room);
                return await unitOfWork.SaveChangesAsync();

            }
        }

    }
}
