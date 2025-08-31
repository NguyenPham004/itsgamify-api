using its.gamify.core;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Categories;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Categories.Commands
{
    public class CreateCategoryCommand : CategoryCreateModel, IRequest<Category>
    {
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, Category>
        {
            public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var checkDupName = await unitOfWork.CategoryRepository.FirstOrDefaultAsync(x => x.Name.ToLower().Trim() == request.Name.ToLower().Trim());
                if (checkDupName != null) throw new BadRequestException("Tên đã tồn tại!");
                var category = unitOfWork.Mapper.Map<Category>(request);
                await unitOfWork.CategoryRepository.AddAsync(category, cancellationToken);
                await unitOfWork.SaveChangesAsync();
                return category;
            }
        }
    }
}
