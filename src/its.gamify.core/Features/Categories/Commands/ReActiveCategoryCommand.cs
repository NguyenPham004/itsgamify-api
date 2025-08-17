using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Categories.Commands
{
    public class ReActiveCategoryCommand : BaseReActiveModel, IRequest<Category>
    {
        public Guid Id { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ReActiveCategoryCommand, Category>
        {
            public async Task<Category> Handle(ReActiveCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.Id, true) ?? throw new BadRequestException("Không tìm thấy thể loại.");
                category.IsDeleted = request.IsActive;
                unitOfWork.CategoryRepository.Update(category);
                await unitOfWork.SaveChangesAsync();
                return category;
            }
        }
    }
}
