using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.Categories;
using its.gamify.core.Models.Questions;
using MediatR;

namespace its.gamify.api.Features.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public CategoryUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateCategoryCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.Name).NotEmpty().NotNull().WithMessage("Name can not null.");;
            }
        }
        class CommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
                if (category is not null)
                {
                    unitOfWork.Mapper.Map(request.Model, category);
                    unitOfWork.CategoryRepository.Update(category);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Category not found");

            }
        }
    }
}
