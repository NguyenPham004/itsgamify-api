using its.gamify.core;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.core.Features.Courses.Queries
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public Guid Id { get; set; }
        class QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetCourseByIdQuery, Course>
        {

            public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
            {
                bool checkRole = claimsService.CurrentRole == ROLE.ADMIN || claimsService.CurrentRole == ROLE.TRAININGSTAFF ||
                                claimsService.CurrentRole == ROLE.MANAGER;
                return (await unitOfWork.CourseRepository.FirstOrDefaultAsync(x => x.Id == request.Id, checkRole, cancellationToken,
                    includeFunc: x => x
                        .Include(x => x.CourseCollections.Where(x => x.UserId == claimsService.CurrentUser && !x.IsDeleted))
                        .Include(course => course.LearningMaterials.Where(x => !x.IsDeleted))
                        .Include(x => x.CourseDepartments.Where(x => x.CourseId == request.Id)).ThenInclude(x => x.Deparment)
                        .Include(x => x.Category)
                        .Include(x => x.Quarter)
                        .Include(course => course.CourseSections.Where(x => !x.IsDeleted))
                            .ThenInclude(cs => cs.Lessons.Where(x => !x.IsDeleted))
                                .ThenInclude(x => x.Quiz)
                                    .ThenInclude(q => q!.Questions.Where(x => !x.IsDeleted))
                                .Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                                .ThenInclude(x => x.Lessons.Where(x => !x.IsDeleted))
                                    .ThenInclude(x => x.Practices)))

                     ?? throw new InvalidOperationException("Không tìm thấy Course với id " + request.Id);
            }
        }
    }
}
