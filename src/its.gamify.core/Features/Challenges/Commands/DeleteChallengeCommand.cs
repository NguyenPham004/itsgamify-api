using its.gamify.api.Features.Categories.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Challenges.Commands
{
    public class DeleteChallengeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteChallengeCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteChallengeCommand request, CancellationToken cancellationToken)
            {
                var challenge = await unitOfWork.ChallengeRepository.GetByIdAsync(request.Id);
                if (challenge is not null)
                {
                    unitOfWork.ChallengeRepository.SoftRemove(challenge);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Challenge not found");
            }
        }

    }
}
