using FluentValidation;
using its.gamify.api.Features.CourseSections.Commands;
using its.gamify.api.Features.LearningMaterials.Commands;
using its.gamify.core;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.CourseSections;
using its.gamify.core.Models.Lessons;
using its.gamify.core.Models.Questions;
using its.gamify.domains.Enums;
using MediatR;

namespace its.gamify.api.Features.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {

        public CourseUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateCourseCommand>
        {
            public CommandValidate()
            {
                When(x => x.Model.Status == CourseStatusEnum.INITIAL.ToString(), () =>
                {
                    RuleFor(x => x.Model.Title).NotEmpty().WithMessage("Vui lòng nhập tiêu đề");
                    RuleFor(x => x.Model.ThumbnailId).NotEmpty().WithMessage("Vui lòng nhập ảnh thumbnail");
                    RuleFor(x => x.Model.IntroVideoId).NotEmpty().WithMessage("Vui lòng nhập intro video");
                    RuleFor(x => x.Model.CategoryId).NotEmpty().WithMessage("Vui lòng chọn danh mục");
                    RuleFor(x => x.Model.Description).NotEmpty().WithMessage("Vui lòng nhập mô tả ngắn");
                    RuleFor(x => x.Model.LongDescription).NotEmpty().WithMessage("Vui lòng nhập mô tả");
                });
                // When(x => x.Model.Status == CourseStatusEnum.MATERIAL.ToString(), () =>
                // {
                //     RuleFor(x => x.Model.LearningMaterialIds).NotEmpty().WithMessage("Vui lòng nhập");
                // });
                When(x => x.Model.Status == CourseStatusEnum.CONTENT.ToString(), () =>
                {
                    RuleForEach(x => x.Model.CourseSections).NotNull().WithMessage("Module đang trống")
                        .SetValidator(new CourseSectionValidator());
                });
                When(x => x.Model.CourseType == CourseTypeEnum.DEPARTMENTONLY.ToString(), () =>
                {
                    RuleFor(x => x.Model.DepartmentId).NotNull()
                        .NotEmpty().WithMessage("Khoá học dành riêng cho phòng ban! Cần chọn phòng ban");
                });


            }
            class CourseSectionValidator : AbstractValidator<CourseSectionUpdateModel>
            {
                public CourseSectionValidator()
                {

                    RuleFor(x => x.Description).NotEmpty().WithMessage("Mô tả của module đang trống");
                    RuleFor(x => x.Title).NotEmpty().WithMessage("Tiêu đề của module đang trống");
                    RuleFor(x => x.OrderedNumber).NotEmpty().WithMessage("Số thứ tự của module đang trống");
                    RuleForEach(x => x.Lessons).NotEmpty().SetValidator(new LessonValidator());
                }
            }
            class LessonValidator : AbstractValidator<LessonUpdateModel>
            {
                public LessonValidator()
                {
                    When(x => x.Type == LearningMaterialType.VIDEO.ToString(), () =>
                    {
                        RuleFor(x => x.Url).NotEmpty().WithMessage("Video Url đang trống");
                    });
                    When(x => x.Type == LearningMaterialType.DOCUMENT.ToString(), () =>
                    {
                        RuleFor(x => x.Content).NotEmpty().WithMessage("Nội dung bài học đang trống");
                    });
                    When(x => x.Type == LearningMaterialType.QUIZ.ToString(), () =>
                    {
                        RuleForEach(x => x.QuestionModels).SetValidator(new QuestionValidator());
                    });

                }
            }
            class QuestionValidator : AbstractValidator<QuestionUpsertModel>
            {
                public QuestionValidator()
                {
                    RuleFor(x => x.Content).NotEmpty().WithMessage("Nội dung câu hỏi đang trống");
                }
            }

        }

        class CommandHandler : IRequestHandler<UpdateCourseCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMediator mediator;
            public CommandHandler(IUnitOfWork unitOfWork,
                IMediator mediator)
            {
                this.mediator = mediator;
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = await unitOfWork.CourseRepository.FirstOrDefaultAsync(x => x.Id == request.Model.Id)
                    ?? throw new InvalidOperationException("Không tìm thấy course với Id " + request.Model.Id);
                unitOfWork.Mapper.Map(request.Model, course);

                course.ThumbnailImage = (await unitOfWork.FileRepository.FirstOrDefaultAsync(x => x.Id == request.Model.ThumbnailId)
                    ?? throw new InvalidOperationException("Không tìm thấy image thumbnail")).Url;
                course.IntroVideo = (await unitOfWork.FileRepository.FirstOrDefaultAsync(x => x.Id == request.Model.IntroVideoId)
                    ?? throw new InvalidOperationException("Không tìm thấy Intro Video với Id ")).Url;

                unitOfWork.CourseRepository.Update(course);
                await unitOfWork.SaveChangesAsync();

                if (request.Model.IsUpdateModule)
                {
                    foreach (var courseSection in request.Model.CourseSections ?? [])
                    {
                        await mediator.Send(new UpsertCourseSectionCommand()
                        {
                            Model = courseSection,
                            SectionId = courseSection.Id
                        }, cancellationToken);
                    }

                }


                return true;


            }
        }
    }
}
