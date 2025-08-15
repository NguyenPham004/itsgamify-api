using FluentValidation;
using its.gamify.core.Features.Challenges.Commands;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Challenges;
using its.gamify.core.Models.Courses;
using its.gamify.domains.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Courses.Commands
{
    public class ReActiveCourseCommand : CourseReActiveModel, IRequest<Course>
    {
        class CommandValidation : AbstractValidator<ReActiveCourseCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Vui lòng nhập course id");
            }
        }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ReActiveCourseCommand, Course>
        {
            public async Task<Course> Handle(ReActiveCourseCommand request, CancellationToken cancellationToken)
            {
                var course = await unitOfWork.CourseRepository.GetByIdAsync(request.Id,true);
                if (course == null) throw new NotFoundException("Không tìm thấy khóa học.");
                course.IsDeleted = request.IsActive;
                unitOfWork.CourseRepository.Update(course);
                await unitOfWork.SaveChangesAsync();
                return course;
            }
        }
    }
}
