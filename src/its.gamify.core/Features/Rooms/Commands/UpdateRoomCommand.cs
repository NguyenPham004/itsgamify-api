using FluentValidation;
using its.gamify.core.Features.Challenges.Commands;
using its.gamify.core.Models.Challenges;
using its.gamify.core.Models.Rooms;
using its.gamify.domains.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Rooms.Commands
{
    public class UpdateRoomCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public RoomUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateRoomCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.ChallengeId).NotEmpty().NotNull().WithMessage("Vui lòng nhập thử thách");
                RuleFor(x => x.Model.AmountQuestion).GreaterThan(0).WithMessage("Số câu hỏi phải lớn hơn 0.");
                RuleFor(x => x.Model.TimeQuestion).GreaterThan(0).WithMessage("Thời gian cho câu hỏi không hợp lệ.");
            }
        }
        class CommandHandler : IRequestHandler<UpdateRoomCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
            {
                var room = await unitOfWork.RoomRepository.GetByIdAsync(request.Id);
                if (room is not null)
                {
                    var mapper = unitOfWork.Mapper.Map(request.Model, new Room());
                    if (room == mapper) return true;
                    unitOfWork.Mapper.Map(request.Model, room);
                    unitOfWork.RoomRepository.Update(room);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Room not found");

            }
        }
    }
}
