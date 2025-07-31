using its.gamify.core.Features.Challenges.Commands;
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
        class CommandHandler : IRequestHandler<DeleteRoomCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
            {
                var room = await unitOfWork.RoomRepository.GetByIdAsync(request.Id);
                if (room is not null)
                {
                    unitOfWork.RoomRepository.SoftRemove(room);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Room not found");
            }
        }

    }
}
