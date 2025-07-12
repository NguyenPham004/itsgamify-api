using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.LearningMaterials.Commands
{
    public class DeleteLearningMaterialCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteLearningMaterialCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteLearningMaterialCommand request, CancellationToken cancellationToken)
            {
                var toRemove = await unitOfWork.LearningMaterialRepository.FirstOrDefaultAsync(x => x.Id == request.Id)
                    ?? throw new InvalidOperationException($"Không tìm thấy learning material với Id {request.Id}");
                unitOfWork.LearningMaterialRepository.SoftRemove(toRemove);
                return await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
