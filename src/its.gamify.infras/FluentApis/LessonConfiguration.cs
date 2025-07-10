using its.gamify.domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace its.gamify.infras.FluentApis;

public class LessonConfiguration : IEntityTypeConfiguration<domains.Entities.Lesson>
{
    public void Configure(EntityTypeBuilder<domains.Entities.Lesson> builder)
    {
        builder.HasOne(x => x.CourseSection)
            .WithMany(x => x.Lessons)
            .HasForeignKey(x => x.CourseSectionId)
            .OnDelete(DeleteBehavior.NoAction); // Ensures that if a course section is deleted, its lessons are also deleted

        builder.Property(x => x.QuizId).IsRequired(false);

        builder.HasOne(x => x.Quiz)
        .WithOne()
        .HasForeignKey<Lesson>(x => x.QuizId)
            .OnDelete(DeleteBehavior.NoAction); // Ensures that if a lesson is deleted, its quizzes are also deleted
    }
}