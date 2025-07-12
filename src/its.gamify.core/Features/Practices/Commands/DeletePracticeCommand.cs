using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.Practices.Commands
{
    public class DeletePracticeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeletePracticeCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeletePracticeCommand request, CancellationToken cancellationToken)
            {
                var practice = await unitOfWork.PracticeTagRepository.FirstOrDefaultAsync(x => x.Id == request.Id)
                    ?? throw new InvalidOperationException($"không tìm thấy practice với id {request.Id}");
                unitOfWork.PracticeTagRepository.SoftRemove(practice);
                return await unitOfWork.SaveChangesAsync();



            }
        }
    }
}
