using its.gamify.core;
using its.gamify.core.Models.DifficultyLevels;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.DifficultyLevels.Commands
{
    public class CreateDifficulty : DifficultyCreateModel, IRequest<Difficulty>
    {
        class CommandHandler : IRequestHandler<CreateDifficulty, Difficulty>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Difficulty> Handle(CreateDifficulty request, CancellationToken cancellationToken)
            {
                var difficulty = unitOfWork.Mapper.Map<Difficulty>(request);
                await unitOfWork.DifficultyRepository.AddAsync(difficulty);
                await unitOfWork.SaveChangesAsync();
                return difficulty;
            }
        }
    }
}
