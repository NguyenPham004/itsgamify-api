using AutoMapper;
using its.gamify.core.Models.Categories;
using its.gamify.core.Models.CourseCollections;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.CourseSections;
using its.gamify.core.Models.Departments;
using its.gamify.core.Models.DifficultyLevels;
using its.gamify.core.Models.LearningMaterials;
using its.gamify.core.Models.Lessons;
using its.gamify.core.Models.Practices;
using its.gamify.core.Models.Quarters;
using its.gamify.core.Models.Questions;
using its.gamify.core.Models.QuizAnswers;
using its.gamify.core.Models.Quizes;
using its.gamify.core.Models.QuizResults;
using its.gamify.core.Models.Users;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;

namespace its.gamify.core.Mappers;

public class MapperConfigurationProfile : Profile
{
    public MapperConfigurationProfile()
    {
        #region Users
        CreateMap<User, UserViewModel>()
            .ForMember(x => x.DeptName, cfg => cfg.MapFrom(x => (x.Department!.Name ?? string.Empty)))
            .ForMember(x => x.RoleName, cfg => cfg.MapFrom(x => x.Role!.Name))
            .ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        CreateMap<User, UserCreateModel>().ForMember(x => x.DepartmentId, cfg => cfg.MapFrom(x => x.DepartmentId))
            .ReverseMap();

        #endregion

        #region Course
        CreateMap<Course, CourseViewModel>().ReverseMap();
        CreateMap<Course, CourseCreateModels>().ReverseMap();
        CreateMap<Course, CourseUpdateModel>().ReverseMap()
            .ForMember(x => x.DurationInHours, cfg => cfg.MapFrom(c => c.CourseSections!.Sum(s => s.Lessons!.Sum(x => x.DurationInMinutes))))
            .ForMember(x => x.Status, cfg => cfg.MapFrom(x => x.Status ?? "UNDEFINED"))
            .ForMember(x => x.IsDraft, cfg => cfg.MapFrom(x => x.IsDraft))
            .ForMember(x => x.CourseSections, cfg => cfg.Ignore());
        #endregion

        #region Department
        CreateMap<Department, DepartmentViewModel>().ForMember(x => x.EmployeeCount, cfg => cfg.MapFrom(c => c.Users!.Count))
                .ForMember(x => x.CourseCount, cfg => cfg.MapFrom(d => d.Courses!.Count))
                .ForMember(x => x.Leader, cfg => cfg.MapFrom(x => x.Users!.FirstOrDefault(x => x.Role!.Name == ROLE.LEADER)))
                .ReverseMap();
        CreateMap<Department, DepartmentCreateModel>().ReverseMap();
        CreateMap<Department, DepartmentUpdateModel>().ReverseMap();
        #endregion

        #region CourseSection
        CreateMap<CourseSection, CourseSectionCreateModel>().ReverseMap();
        CreateMap<CourseSection, CourseSectionUpdateModel>()
            .ForMember(x => x.Lessons, op => op.Ignore())
            .ReverseMap();

        #endregion


        #region Lesson
        CreateMap<Lesson, LessonCreateModel>().ReverseMap();
        CreateMap<Lesson, LessonUpdateModel>()
            .ForMember(x => x.QuestionModels, op => op.Ignore())
            .ReverseMap();

        #endregion

        #region Learning material
        CreateMap<LearningMaterial, LearningMaterialCreateModel>().ReverseMap();
        #endregion

        CreateMap<Category, CategoryCreateModel>().ReverseMap();
        CreateMap<Category, CategoryViewModel>().ReverseMap();
        CreateMap<Category, CategoryUpdateModel>().ReverseMap();

        CreateMap<Quarter, QuarterCreateModel>().ReverseMap();

        CreateMap<Difficulty, DifficultyCreateModel>().ReverseMap();
        CreateMap<Quiz, QuizCreateModel>().ReverseMap();
        CreateMap<Quiz, QuizUpdateModel>().ReverseMap();
        CreateMap<Quiz, QuizViewModel>().ReverseMap();

        CreateMap<QuizResult, QuizResultCreateModel>().ReverseMap();
        CreateMap<QuizResult, QuizResultUpdateModel>().ReverseMap();
        CreateMap<QuizResult, QuizResultViewModel>().ReverseMap();
        CreateMap<Question, QuestionUpsertModel>().ReverseMap();

        CreateMap<QuizAnswer, QuizAnswerCreateModel>().ReverseMap();
        CreateMap<QuizAnswer, QuizAnswerUpdateModel>().ReverseMap();
        CreateMap<QuizAnswer, QuizAnswerViewModel>().ReverseMap();

        CreateMap<CourseCollection, CourseCollectionCreateModel>().ReverseMap();
        CreateMap<CourseCollection, CourseCollectionUpdateModel>().ReverseMap();
        CreateMap<CourseCollection, CourseCollectionViewModel>().ReverseMap();

        CreateMap<PracticeTag, PracticeUpsertModel>().ReverseMap();
    }
}
