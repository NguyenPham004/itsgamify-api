using AutoMapper;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.Departments;
using its.gamify.core.Models.Questions;
using its.gamify.core.Models.Users;
using its.gamify.domains.Entities;

namespace its.gamify.core.Mappers;
public class MapperConfigurationProfile : Profile
{
    public MapperConfigurationProfile()
    {
        #region Users
        CreateMap<User, UserViewModel>()
            .ForMember(x => x.DeptName, cfg => cfg.MapFrom(x => (x.Department!.Name ?? string.Empty)))
            .ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        CreateMap<User, UserCreateModel>().ForMember(x => x.DeptId, cfg => cfg.MapFrom(x => x.DepartmentId))
            .ReverseMap();

        #endregion

        #region Course
        CreateMap<Course, CourseViewModel>().ReverseMap();
        CreateMap<Course, CourseCreateModel>().ReverseMap();
        CreateMap<Course, CourseUpdateModel>().ReverseMap();
        #endregion

        #region Department
        CreateMap<Department, DepartmentViewModel>().ReverseMap();
        CreateMap<Department, DepartmentCreateModel>().ReverseMap();
        CreateMap<Department, DepartmentUpdateModel>().ReverseMap();
        #endregion

        #region Question
        CreateMap<Question, QuestionViewModel>().ReverseMap();
        CreateMap<Question, QuestionCreateModel>().ReverseMap();
        CreateMap<Question, QuestionUpdateModel>().ReverseMap();

        #endregion

        #region Quiz
        #endregion

        #region Quiz result
        #endregion

        #region Quiz answer
        #endregion
    }
}
