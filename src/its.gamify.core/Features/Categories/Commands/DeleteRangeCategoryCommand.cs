using its.gamify.api.Features.Departments.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Categories.Commands
{
    public class DeleteRangeCategoryCommand : IRequest<bool>
    {
        public List<Guid> Ids { get; set; } = new List<Guid>();
        class CommandHandler : IRequestHandler<DeleteRangeCategoryCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteRangeCategoryCommand request, CancellationToken cancellationToken)
            {
                var listCategory = await unitOfWork.CategoryRepository.WhereAsync(p => request.Ids.Contains(p.Id));
                //var question = await unitOfWork.DepartmentRepository.GetByIdAsync(request.Id);
                if (listCategory.Count > 0)
                {
                    unitOfWork.CategoryRepository.SoftRemoveRange(listCategory);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Category not found");
            }
        }

    }
}
