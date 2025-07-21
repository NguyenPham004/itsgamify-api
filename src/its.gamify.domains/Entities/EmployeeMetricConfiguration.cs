using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.domains.Entities
{
    public class EmployeeMetricConfiguration : IEntityTypeConfiguration<EmployeeMetric>
    {
        public void Configure(EntityTypeBuilder<EmployeeMetric> builder)
        {
            builder.HasOne(em => em.User)
               .WithMany(u => u.EmployeeMetrics)
               .HasForeignKey(em => em.UserId);

            builder.HasOne(em => em.Quarter)
                   .WithMany(q => q.EmployeeMetrics)
                   .HasForeignKey(em => em.QuarterId);
        }
    }
}
