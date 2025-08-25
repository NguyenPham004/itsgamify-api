using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace its.gamify.infras.Datas;

public class AppDbContext : DbContext
{
    private DbSet<User> user;
    private DbSet<Role> role;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
    public DbSet<FileEntity> File { get; set; }
    public DbSet<User> User { get => user; set => user = value; }
    public DbSet<Role> Role { get => role; set => role = value; }
    public DbSet<CourseCollection> CourseCollection { get; set; }
    public DbSet<QuizResult> QuizResult { get; set; }
    public DbSet<QuizAnswer> QuizAnswer { get; set; }
    public DbSet<Quiz> Quiz { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Quarter> Quarter { get; set; }
    public DbSet<PracticeTag> PracticeTag { get; set; }

    public DbSet<Notification> Notification { get; set; }
    public DbSet<Lesson> Lesson { get; set; }
    public DbSet<LearningProgress> LearningProgress { get; set; }
    public DbSet<LearningMaterial> LearningMaterial { get; set; }
    public DbSet<UserMetric> UserMetrics { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<CourseSection> CourseSection { get; set; }
    public DbSet<CourseReview> CourseReview { get; set; }
    public DbSet<CourseResult> CourseResult { get; set; }
    public DbSet<CourseParticipation> CourseParticipation { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<Challenge> Challenge { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Badge> Badge { get; set; }
    public DbSet<CourseMetric> CourseMetric { get; set; }
    public DbSet<UserChallengeHistory> UserChallengeHistory { get; set; }
    public DbSet<CourseDepartment> CourseDepartment { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<RoomUser> RoomUser { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings =>
     warnings.Ignore(RelationalEventId.PendingModelChangesWarning));


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PracticeTag>().HasOne(x => x.Lesson)
            .WithMany(x => x.Practices)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.ApplyConfigurationsFromAssembly(its.gamify.infras.AssemblyReference.Assembly);
        Role[] roles = [new Role()
        {
            Id = Guid.Parse("71874fd3-1892-4d92-a77f-c85c0d16b8db"),
            Name = RoleEnum.EMPLOYEE.ToString()
        }, new Role()
        {
                Id = Guid.Parse("620d170e-c32e-4443-b450-32848c1eb5e9"),
            Name = RoleEnum.LEADER.ToString()
        }, new Role() {
                Id = Guid.Parse("3b72db68-b2c6-40d8-859e-b4996f8535a1"),
            Name = RoleEnum.TRAININGSTAFF.ToString()}, new Role()
        {
                    Id = Guid.Parse("f7fa7c6b-f76a-4b95-8711-517eb8205a1a"),
            Name = RoleEnum.MANAGER.ToString()
        }, new Role()
        {     Id = Guid.Parse("b002d347-66b9-4722-9547-5b2165abaa9f"),
            Name = RoleEnum.ADMIN.ToString()}];


        modelBuilder.Entity<Role>().HasData(roles);
    }
}