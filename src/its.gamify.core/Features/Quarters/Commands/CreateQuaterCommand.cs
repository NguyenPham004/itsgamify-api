using FluentValidation;
using its.gamify.core;
using its.gamify.core.Models.Quarters;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Quarters.Commands
{
    public class CreateQuaterCommand : QuarterCreateModel, IRequest<Quarter>
    {
        class CommandValidation : AbstractValidator<CreateQuaterCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.EndDate).NotNull().NotEmpty().GreaterThan(x => x.StartDate);
                RuleFor(x => x.EndDate).NotNull().NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
                RuleFor(x => x.Name).NotNull().NotEmpty();
            }
        }
        class CommandHandler : IRequestHandler<CreateQuaterCommand, Quarter>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;

            }
            public async Task<Quarter> Handle(CreateQuaterCommand request, CancellationToken cancellationToken)
            {
                var quarter = unitOfWork.Mapper.Map<Quarter>(request);
                await unitOfWork.QuarterRepository.AddAsync(quarter);
                await unitOfWork.SaveChangesAsync();
                return quarter;
            }
        }
    }
}
