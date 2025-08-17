using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using MediatR;

namespace its.gamify.api.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
                if (category is not null)
                {
                    unitOfWork.CategoryRepository.SoftRemove(category);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new BadRequestException("Không tìm thấy mục này!");
            }
        }

    }
}
