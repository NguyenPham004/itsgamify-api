

using its.gamify.domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace its.gamify.infras.FluentApis
{
    public class CourseConfiguration
    {
    }


    public class CourseDepartmentConfiguration : IEntityTypeConfiguration<CourseDepartment>
    {
        public void Configure(EntityTypeBuilder<CourseDepartment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Course)
                .WithMany(x => x.CourseDepartments)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.CourseDepartments)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}



