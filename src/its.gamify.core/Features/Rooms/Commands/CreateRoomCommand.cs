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
    public class CreateRoomCommand : RoomCreateModel, IRequest<Room>
    {
        class CommandValidation : AbstractValidator<CreateRoomCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.ChallengeId).NotNull().NotEmpty().WithMessage("Vui lòng nhập challenge id.");
                RuleFor(x => x.AmountQuestion).GreaterThan(0).WithMessage("Số câu hỏi phải lớn hơn 0.");
                RuleFor(x => x.TimeQuestion).GreaterThan(0).WithMessage("Thời gian cho câu hỏi không hợp lệ.");
            }
        }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRoomCommand, Room>
        {
            public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.ChallengeRepository.EnsureExistsIfIdNotEmpty(request.ChallengeId);
                var room = unitOfWork.Mapper.Map<Room>(request);
                await unitOfWork.RoomRepository.AddAsync(room, cancellationToken);
                await unitOfWork.SaveChangesAsync();
                return room;
            }
        }
    }
}
