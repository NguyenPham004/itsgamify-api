using its.gamify.core;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.api.Features.Courses.Queries
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public Guid Id { get; set; }
        class QueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IClaimsService claimsService;
            public QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
            {
                this.unitOfWork = unitOfWork;
                this.claimsService = claimsService;
            }
            public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
            {
                bool checkRole = claimsService.CurrentRole == ROLE.ADMIN || claimsService.CurrentRole == ROLE.TRAININGSTAFF ||
                                claimsService.CurrentRole == ROLE.MANAGER;
                return (await unitOfWork.CourseRepository.FirstOrDefaultAsync(x => x.Id == request.Id, checkRole, cancellationToken,
                    includeFunc: x => x.Include(course => course.LearningMaterials.Where(x => !x.IsDeleted))
                        .Include(x => x.Deparment)
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
