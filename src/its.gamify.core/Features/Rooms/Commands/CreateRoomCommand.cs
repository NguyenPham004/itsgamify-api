using FluentValidation;
using its.gamify.core.Models.Rooms;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Rooms.Commands
{
    public class CreateRoomCommand : RoomCreateModel, IRequest<Room>
    {
        class CommandValidation : AbstractValidator<CreateRoomCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.ChallengeId).NotNull().NotEmpty().WithMessage("Vui lòng nhập challenge id.");
                RuleFor(x => x.QuestionCount).GreaterThan(0).WithMessage("Số câu hỏi phải lớn hơn 0.");
                RuleFor(x => x.TimePerQuestion).GreaterThan(0).WithMessage("Thời gian cho câu hỏi không hợp lệ.");
            }
        }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateRoomCommand, Room>
        {
            public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.ChallengeRepository.EnsureExistsIfIdNotEmpty(request.ChallengeId);
                var room = unitOfWork.Mapper.Map<Room>(request);
                room.RoomCode = StringUtilities.GenerateRandomCode();
                var roomUser = new RoomUser
                {
                    RoomId = room.Id,
                    UserId = request.HostUserId,
                    IsOutRoom = false,
                    CurrentScore = 0,
                    CorrectAnswers = 0,
                    IsCurrentQuestionAnswered = false
                };
                await unitOfWork.RoomRepository.AddAsync(room, cancellationToken);
                await unitOfWork.RoomUserRepository.AddAsync(roomUser, cancellationToken);
                await unitOfWork.SaveChangesAsync();
                return room;
            }
        }
    }
}
