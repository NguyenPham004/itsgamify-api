using its.gamify.core.Models.Lessons;
using its.gamify.domains.Entities;
using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Courses;


public static class CourseStatusConstants
{
    public const string INITIAL_STEP = "INITIAL_STEP";
    public const string CONTENT_STEP = "CONTENT_STEP";
    public const string MATERIAL_STEP = "MATERIAL_STEP";
    public const string PUBLISH_STEP = "PUBLISH_STEP";
}


public class CourseStateTransition<TResult>
{
    public string[] From { get; set; } = default!;
    public string To { get; set; } = default!;
    public Func<Course, bool>? Guard { get; set; }
    public Func<CourseCreateModels, Task<bool>>? Validate { get; set; }
    public Func<(Course course, CourseCreateModels model), Task<TResult>>? Action { get; set; }
}

#region  model

public class CourseViewModel
{
    public string Title { get; set; } = string.Empty;
    public double DurationInHours { get; set; } = 0.0;
    public string Description { get; set; } = string.Empty;
    public Guid QuarterId { get; set; }
    public Guid DifficultyLevelId { get; set; }
    public Guid CategoryId { get; set; }
}


public class QuestionCreateModel
{
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    [JsonPropertyName("question")]
    public string? Question { get; set; }

    [JsonPropertyName("answer_A")]
    public string? AnswerA { get; set; }

    [JsonPropertyName("answer_B")]
    public string? AnswerB { get; set; }

    [JsonPropertyName("answer_C")]
    public string? AnswerC { get; set; }

    [JsonPropertyName("answer_D")]
    public string? AnswerD { get; set; }

    [JsonPropertyName("correct_answer")]
    public string? CorrectAnswer { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}



public class ModuleCreateModel
{
    // [JsonPropertyName("id")]
    // public string? Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("lessons")]
    public List<LessonCreateModel>? Lessons { get; set; }
}

public class CourseCreateModel
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("short_description")]
    public string? ShortDescription { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("thumbnail_image_id")]
    public string? ThumbnailImageId { get; set; }

    [JsonPropertyName("introduction_video_id")]
    public string? IntroductionVideoId { get; set; }

    [JsonPropertyName("classify")]
    public string? Classify { get; set; }

    [JsonPropertyName("department_id")]
    public string? DepartmentId { get; set; }

    [JsonPropertyName("category_id")]
    public string? CategoryId { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("modules")]
    public List<ModuleCreateModel>? Modules { get; set; }

    [JsonPropertyName("file_ids")]
    public List<string>? FileIds { get; set; }

    [JsonPropertyName("requirement")]
    public string? Requirement { get; set; }

    [JsonPropertyName("targets")]
    public List<string>? Targets { get; set; }
}

#endregion

// public class CourseCreateModelValidator : AbstractValidator<CourseCreateModel>
// {
//     public CourseCreateModelValidator(string courseState)
//     {
//         // Validation rules based on course state
//         switch (courseState)
//         {
//             case CourseStatusConstants.INITIAL_STEP:
//                 ApplyInitialStepValidation();
//                 break;
//             case CourseStatusConstants.CONTENT_STEP:
//                 ApplyContentStepValidation();
//                 break;
//             case CourseStatusConstants.MATERIAL_STEP:
//                 ApplyMaterialStepValidation();
//                 break;
//             case CourseStatusConstants.PUBLISH_STEP:
//                 ApplyPublishStepValidation();
//                 break;
//             default:
//                 throw new ArgumentException($"Unknown course state: {courseState}");
//         }
//     }

//     private void ApplyInitialStepValidation()
//     {
//         // Basic information validation - equivalent to basicFormSchema in Yup
//         RuleFor(x => x.Title)
//             .NotEmpty().WithMessage("Title is required");

//         RuleFor(x => x.ShortDescription)
//             .NotEmpty().WithMessage("Short description is required");

//         RuleFor(x => x.Description)
//             .NotEmpty().WithMessage("Description is required");

//         RuleFor(x => x.ThumbnailImageId)
//             .NotEmpty().WithMessage("Thumbnail image is required");

//         RuleFor(x => x.IntroductionVideoId)
//             .NotEmpty().WithMessage("Introduction video is required");

//         RuleFor(x => x.Classify)
//             .NotEmpty().WithMessage("Classification is required");

//         RuleFor(x => x.DepartmentId)
//             .NotEmpty().WithMessage("Department is required");

//         RuleFor(x => x.CategoryId)
//             .NotEmpty().WithMessage("Category is required");

//         RuleFor(x => x.Tags)
//             .NotNull().WithMessage("Tags are required")
//             .Must(tags => tags != null && tags.Count > 0).WithMessage("At least one tag is required");
//     }

//     private void ApplyContentStepValidation()
//     {
//         // Content step validation - validate modules and lessons
//         RuleFor(x => x.Modules)
//             .NotNull().WithMessage("Modules are required")
//             .Must(modules => modules != null && modules.Count > 0).WithMessage("At least one module is required");

//         RuleForEach(x => x.Modules)
//             .ChildRules(module =>
//             {
//                 module.RuleFor(m => m.Title)
//                     .NotEmpty().WithMessage("Module title is required");

//                 module.RuleFor(m => m.Description)
//                     .NotEmpty().WithMessage("Module description is required");

//                 module.RuleFor(m => m.Lessons)
//                     .NotNull().WithMessage("Lessons are required")
//                     .Must(lessons => lessons != null && lessons.Count > 0).WithMessage("At least one lesson is required");

//                 module.RuleForEach(m => m.Lessons)
//                     .ChildRules(lesson =>
//                     {
//                         lesson.RuleFor(l => l.Title)
//                             .NotEmpty().WithMessage("Lesson title is required");

//                         lesson.RuleFor(l => l.Type)
//                             .NotEmpty().WithMessage("Lesson type is required")
//                             .Must(type => type == "video" || type == "article" || type == "quiz")
//                             .WithMessage("Lesson type must be 'video', 'article', or 'quiz'");

//                         lesson.RuleFor(l => l.Duration)
//                             .GreaterThan(0).WithMessage("Duration must be greater than 0");

//                         // Conditional validation based on lesson type
//                         lesson.When(l => l.Type == "video", () =>
//                         {
//                             lesson.RuleFor(l => l.VideoUrl)
//                                 .NotEmpty().WithMessage("Video URL is required for video lessons");
//                         });

//                         lesson.When(l => l.Type == "article", () =>
//                         {
//                             lesson.RuleFor(l => l.Content)
//                                 .NotEmpty().WithMessage("Content is required for article lessons");
//                         });

//                         lesson.When(l => l.Type == "quiz", () =>
//                         {
//                             lesson.RuleFor(l => l.Questions)
//                                 .NotNull().WithMessage("Questions are required for quiz lessons")
//                                 .Must(questions => questions != null && questions.Count > 0)
//                                 .WithMessage("At least one question is required for quiz lessons");
//                         });
//                     });
//             });
//     }

//     private void ApplyMaterialStepValidation()
//     {
//         // Material step validation
//         RuleFor(x => x.FileIds)
//             .NotNull().WithMessage("File IDs are required")
//             .Must(fileIds => fileIds != null && fileIds.Count > 0)
//             .WithMessage("At least one file is required");
//     }

//     private void ApplyPublishStepValidation()
//     {
//         // Publish step validation
//         RuleFor(x => x.Requirement)
//             .NotEmpty().WithMessage("Requirement is required");

//         RuleFor(x => x.Targets)
//             .NotNull().WithMessage("Targets are required")
//             .Must(targets => targets != null && targets.Count > 0)
//             .WithMessage("At least one target is required");
//     }
// }