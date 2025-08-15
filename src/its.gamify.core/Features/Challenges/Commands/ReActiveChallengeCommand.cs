using FluentValidation;
using its.gamify.core.Features.Courses.Commands;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Challenges;
using its.gamify.core.Models.Courses;
using its.gamify.domains.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Challenges.Commands
{
    public class ReActiveChallengeCommand : ChallengeReActiveModel, IRequest<Challenge>
    {
        class CommandValidation : AbstractValidator<ReActiveChallengeCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Vui lòng nhập challenge id");
            }
        }
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
