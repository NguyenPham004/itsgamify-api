using FluentValidation;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Rooms;
using its.gamify.domains.Entities;
using MediatR;


namespace its.gamify.core.Features.Rooms.Commands
{
    public class UpdateRoomCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public required RoomUpdateModel Model { get; set; }
        class CommandValidate : AbstractValidator<UpdateRoomCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.ChallengeId).NotEmpty().NotNull().WithMessage("Vui lòng nhập thử thách");
                RuleFor(x => x.Model.QuestionCount).GreaterThan(0).WithMessage("Số câu hỏi phải lớn hơn 0.");
                RuleFor(x => x.Model.TimePerQuestion).GreaterThan(0).WithMessage("Thời gian cho câu hỏi không hợp lệ.");
            }
        }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateRoomCommand, bool>
        {

            public async Task<bool> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
            {
                var room = await unitOfWork.RoomRepository.GetByIdAsync(request.Id) ?? throw new BadRequestException("Phòng không tồn tại!");
                var mapper = unitOfWork.Mapper.Map(request.Model, new Room());
                if (room == mapper) return true;
                unitOfWork.Mapper.Map(request.Model, room);
                unitOfWork.RoomRepository.Update(room);
                return await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
