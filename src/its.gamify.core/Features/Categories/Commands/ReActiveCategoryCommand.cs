using its.gamify.core.Features.Courses.Commands;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models;
using its.gamify.domains.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Categories.Commands
{
    public class ReActiveCategoryCommand : BaseReActiveModel, IRequest<Category>
    {
        public Guid Id { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ReActiveCategoryCommand, Category>
        {
            public async Task<Category> Handle(ReActiveCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.Id, true);
                if (category == null) throw new NotFoundException("Không tìm thấy thể loại.");
                category.IsDeleted = request.IsActive;
                unitOfWork.CategoryRepository.Update(category);
                await unitOfWork.SaveChangesAsync();
                return category;
            }
        }
    }
}
