﻿using FluentValidation;
using its.gamify.core.Models.Challenges;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Challenges.Commands
{
    public class CreateChallengeCommand : ChallengeCreateModel, IRequest<Challenge>
    {
        class CommandValidation : AbstractValidator<CreateChallengeCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.CourseId).NotNull().NotEmpty().WithMessage("Vui lòng nhập course id");
                RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Vui lòng nhập tên cho thử thách");
                RuleFor(x => x.NumOfRoom).GreaterThan(0).WithMessage("Số lượng phòng trong thử thách phải lớn hơn 0");
            }
        }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateChallengeCommand, Challenge>
        {
            public async Task<Challenge> Handle(CreateChallengeCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.CourseRepository.EnsureExistsIfIdNotEmpty(request.CourseId);
                var challenge = unitOfWork.Mapper.Map<Challenge>(request);
                await unitOfWork.ChallengeRepository.AddAsync(challenge, cancellationToken);
                await unitOfWork.SaveChangesAsync();
                return challenge;
            }
        }
    }
}
