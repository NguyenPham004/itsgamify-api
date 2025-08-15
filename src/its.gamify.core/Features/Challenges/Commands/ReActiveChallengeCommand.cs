using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Challenges;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Challenges.Commands
{
    public class ReActiveChallengeCommand : ChallengeReActiveModel, IRequest<Challenge>
    {
        public Guid Id { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ReActiveChallengeCommand, Challenge>
        {
            public async Task<Challenge> Handle(ReActiveChallengeCommand request, CancellationToken cancellationToken)
            {
                var challenge = await unitOfWork.ChallengeRepository.GetByIdAsync(request.Id,true);
                if (challenge == null) throw new NotFoundException("Không tìm thấy thử thách.");
                challenge.IsDeleted = request.IsActive;
                unitOfWork.ChallengeRepository.Update(challenge);
                await unitOfWork.SaveChangesAsync();
                return challenge;
            }
        }
    }
}
