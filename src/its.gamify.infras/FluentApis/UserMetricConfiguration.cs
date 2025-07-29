using its.gamify.domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.infras.FluentApis
{
    public class UserMetricConfiguration : IEntityTypeConfiguration<UserMetric>
    {
        public void Configure(EntityTypeBuilder<UserMetric> builder)
        {
            builder.HasOne(em => em.User)
               .WithMany(u => u.UserMetrics)
               .HasForeignKey(em => em.UserId);

            builder.HasOne(em => em.Quarter)
                   .WithMany(q => q.UserMetrics)
                   .HasForeignKey(em => em.QuarterId);
        }
    }
}
