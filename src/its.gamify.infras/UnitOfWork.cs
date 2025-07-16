using AutoMapper;
using its.gamify.core;
using its.gamify.core.Repositories;
using its.gamify.infras.Datas;

using Microsoft.Extensions.DependencyInjection;

namespace its.gamify.infras
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository roleRepository;

        private readonly IPracticeTagRepository practiceTagRepository;
        private readonly IBadgeRepository _badgeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDifficultyRepository _difficultyRepository;
        private readonly IEmployeeMetricRepository _employeeMetricRepository;
        private readonly ILeaderBoardRepository _leaderBoardRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly ICourseSectionRepository _courseSectionRepository;
        private readonly ILearningProgressRepository _learningProgressRepository;
        private readonly ICourseReviewRepository _courseReviewRepository;
        private readonly ICourseParticipationRepository _courseParticipationRepository;
        private readonly ICourseCollectionRepository _courseCollectionRepository;
        private readonly ICourseResultRepository _courseResultRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IQuarterRepository _quarterRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IQuizAnswerRepository _quizAnswerRepository;
        private readonly IQuizResultRepository _quizResultRepository;
        private readonly IChallengeRepository _challengeRepository;
        private readonly IChallengeParticipationRepository _challengeParticipationRepository;
        private readonly ILearningMaterialRepository learningMaterialRepository;
        private readonly IFileRepository _fileRepository;
        private readonly ICourseMetricRepository _courseMetricRepository;

        private readonly IMapper mapper;
        public UnitOfWork(AppDbContext dbContext, ICourseRepository courseRepository, IDepartmentRepository departmentRepository,
            IServiceProvider serviceProvider)
        {
            _fileRepository = serviceProvider.GetRequiredService<IFileRepository>();
            roleRepository = serviceProvider.GetRequiredService<IRoleRepository>();
            _userRepository = serviceProvider.GetRequiredService<IUserRepository>();
            mapper = serviceProvider.GetRequiredService<IMapper>();
            _appDbContext = dbContext;
            learningMaterialRepository = serviceProvider.GetRequiredService<ILearningMaterialRepository>();
            _courseRepository = courseRepository;
            practiceTagRepository = serviceProvider.GetRequiredService<IPracticeTagRepository>();

            _departmentRepository = departmentRepository;
            _badgeRepository = serviceProvider.GetRequiredService<IBadgeRepository>();
            _categoryRepository = serviceProvider.GetRequiredService<ICategoryRepository>();
            _difficultyRepository = serviceProvider.GetRequiredService<IDifficultyRepository>();
            _employeeMetricRepository = serviceProvider.GetRequiredService<IEmployeeMetricRepository>();
            _leaderBoardRepository = serviceProvider.GetRequiredService<ILeaderBoardRepository>();
            _lessonRepository = serviceProvider.GetRequiredService<ILessonRepository>();
            _courseSectionRepository = serviceProvider.GetRequiredService<ICourseSectionRepository>();
            _learningProgressRepository = serviceProvider.GetRequiredService<ILearningProgressRepository>();
            _courseReviewRepository = serviceProvider.GetRequiredService<ICourseReviewRepository>();
            _courseParticipationRepository = serviceProvider.GetRequiredService<ICourseParticipationRepository>();
            _courseCollectionRepository = serviceProvider.GetRequiredService<ICourseCollectionRepository>();
            _courseResultRepository = serviceProvider.GetRequiredService<ICourseResultRepository>();
            _notificationRepository = serviceProvider.GetRequiredService<INotificationRepository>();
            _quarterRepository = serviceProvider.GetRequiredService<IQuarterRepository>();
            _questionRepository = serviceProvider.GetRequiredService<IQuestionRepository>();
            _quizRepository = serviceProvider.GetRequiredService<IQuizRepository>();
            _quizAnswerRepository = serviceProvider.GetRequiredService<IQuizAnswerRepository>();
            _quizResultRepository = serviceProvider.GetRequiredService<IQuizResultRepository>();
            _challengeRepository = serviceProvider.GetRequiredService<IChallengeRepository>();
            _challengeParticipationRepository = serviceProvider.GetRequiredService<IChallengeParticipationRepository>();
            _courseMetricRepository = serviceProvider.GetRequiredService<ICourseMetricRepository>();
        }
        public ICourseRepository CourseRepository => _courseRepository;
        public IMapper Mapper => mapper;
        public IUserRepository UserRepository => _userRepository;
        public IDepartmentRepository DepartmentRepository => _departmentRepository;
        public IRoleRepository RoleRepository => roleRepository;

        public IPracticeTagRepository PracticeTagRepository => practiceTagRepository;
        public IBadgeRepository BadgeRepository => _badgeRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public IDifficultyRepository DifficultyRepository => _difficultyRepository;
        public IEmployeeMetricRepository EmployeeMetricRepository => _employeeMetricRepository;
        public ILeaderBoardRepository LeaderBoardRepository => _leaderBoardRepository;
        public ILessonRepository LessonRepository => _lessonRepository;
        public ICourseSectionRepository CourseSectionRepository => _courseSectionRepository;
        public ILearningProgressRepository LearningProgressRepository => _learningProgressRepository;
        public ICourseReviewRepository CourseReviewRepository => _courseReviewRepository;
        public ICourseParticipationRepository CourseParticipationRepository => _courseParticipationRepository;
        public ICourseCollectionRepository CourseCollectionRepository => _courseCollectionRepository;
        public ICourseResultRepository CourseResultRepository => _courseResultRepository;
        public INotificationRepository NotificationRepository => _notificationRepository;
        public IQuarterRepository QuarterRepository => _quarterRepository;
        public IQuestionRepository QuestionRepository => _questionRepository;
        public IQuizRepository QuizRepository => _quizRepository;
        public IFileRepository FileRepository => _fileRepository;
        public IQuizAnswerRepository QuizAnswerRepository => _quizAnswerRepository;
        public IQuizResultRepository QuizResultRepository => _quizResultRepository;
        public IChallengeRepository ChallengeRepository => _challengeRepository;
        public ILearningMaterialRepository LearningMaterialRepository => learningMaterialRepository;
        public IChallengeParticipationRepository ChallengeParticipationRepository => _challengeParticipationRepository;
        public ICourseMetricRepository CourseMetricRepository => _courseMetricRepository;
        public async Task<bool> SaveChangesAsync()
        => await _appDbContext.SaveChangesAsync() > 0;


    }
}

// In your Program.cs (or Startup.cs for older .NET versions), configure JSON options to ignore cycles:
// For .NET 6+ minimal hosting model:
//
// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
// });
// var app = builder.Build();
// app.MapControllers();
// app.Run();
//
// For .NET 5 and earlier, or if you prefer Startup.cs:
//
// public class Startup
// {
//     public void ConfigureServices(IServiceCollection services)
//     {
//         services.AddControllers().AddJsonOptions(options =>
//         {
//             options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//         });
//     }
//
//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//     {
//         if (env.IsDevelopment())
//         {
//             app.UseDeveloperExceptionPage();
//         }
//         else
//         {
//             app.UseExceptionHandler("/Home/Error");
//             app.UseHsts();
//         }
//         app.UseHttpsRedirection();
//         app.UseStaticFiles();
//
//         app.UseRouting();
//
//         app.UseAuthorization();
//
//         app.UseEndpoints(endpoints =>
//         {
//             endpoints.MapControllers();
//         });
//     }
// }
