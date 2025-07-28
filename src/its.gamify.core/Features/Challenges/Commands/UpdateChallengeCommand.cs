using FluentValidation;
using its.gamify.api.Features.Categories.Commands;
using its.gamify.core.Models.Categories;
using its.gamify.core.Models.Challenges;
using its.gamify.domains.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Challenges.Commands
{
    public class UpdateChallengeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public ChallengeUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateChallengeCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.Title).NotEmpty().NotNull().WithMessage("Vui lòng nhập tên cho thử thách"); ;
            }
        }
        class CommandHandler : IRequestHandler<UpdateChallengeCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateChallengeCommand request, CancellationToken cancellationToken)
            {
                var challenge = await unitOfWork.ChallengeRepository.GetByIdAsync(request.Id);
                if (challenge is not null)
                {
                    var mapper = unitOfWork.Mapper.Map(request.Model, new Challenge());
                    if (challenge == mapper) return true;
                    unitOfWork.Mapper.Map(request.Model, challenge);
                    unitOfWork.ChallengeRepository.Update(challenge);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Challenge not found");

            }
        }
    }
}
