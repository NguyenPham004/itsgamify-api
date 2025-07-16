using System.Text.Json;
using its.gamify.domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace its.gamify.infras.FluentApis;

public class LessonConfiguration : IEntityTypeConfiguration<domains.Entities.Lesson>
{
    public void Configure(EntityTypeBuilder<domains.Entities.Lesson> builder)
    {
        var storageComparer = new ValueComparer<List<FileEntity>>(
                 (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2),
                 c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                 c => c.ToList()
             );
        builder.Property(b => b.ImageFiles)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<FileEntity>>(v, (JsonSerializerOptions?)null) ?? new()
                )
                .HasColumnType("json")
                .Metadata.SetValueComparer(storageComparer);

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