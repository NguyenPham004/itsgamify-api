using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using Microsoft.EntityFrameworkCore;
namespace its.gamify.infras.Datas;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private DbSet<User> user;
    private DbSet<Role> role;

    public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<FileEntity> File { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<User> User { get => user; set => user = value; }
    public Microsoft.EntityFrameworkCore.DbSet<Role> Role { get => role; set => role = value; }
    public Microsoft.EntityFrameworkCore.DbSet<WishList> WishList { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<QuizResult> QuizResult { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<QuizAnswer> QuizAnswer { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Quiz> Quiz { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Question> Question { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Quarter> Quarter { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<PracticeTag> PracticeTag { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Practice> Practice { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Notification> Notification { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Lesson> Lesson { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<LearningProgress> LearningProgress { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<LearningMaterial> LearningMaterial { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<LeadearBoard> LeadearBoard { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<EmployeeMetric> EmployeeMetric { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Difficulty> Difficulty { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Department> Department { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<CourseSection> CourseSection { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<CourseReview> CourseReview { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<CourseResult> CourseResult { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<CourseParticipation> CourseParticipation { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Course> Course { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<ChallengeParticipation> ChallengeParticipation { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Challenge> Challenge { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Category> Category { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Badge> Badge { get; set; }

    protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        Role[] roles = [new Role()
        {
            Name = RoleEnum.Employee.ToString()
        }, new Role()
        {
            Name = RoleEnum.Leader.ToString()
        }, new Role() { Name = RoleEnum.TrainingStaff.ToString()}, new Role()
        {
            Name = RoleEnum.Manager.ToString()
        }, new Role()
        { Name = RoleEnum.Admin.ToString()}];


        modelBuilder.Entity<Role>().HasData(roles);
        modelBuilder.ApplyConfigurationsFromAssembly(its.gamify.infras.AssemblyReference.Assembly);
    }
}