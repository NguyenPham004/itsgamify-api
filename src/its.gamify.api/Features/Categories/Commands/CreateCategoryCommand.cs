using its.gamify.core;
using its.gamify.core.Models.Categories;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Categories.Commands
{
    public class CreateCategoryCommand : CategoryCreateModel, IRequest<Category>
    {
        class CommandHandler : IRequestHandler<CreateCategoryCommand, Category>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = unitOfWork.Mapper.Map<Category>(request);
                await unitOfWork.CategoryRepository.AddAsync(category);
                await unitOfWork.SaveChangesAsync();
                return category;
            }
        }
    }
}
