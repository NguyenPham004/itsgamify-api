using its.gamify.domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace its.gamify.infras.FluentApis
{
    public class UserChallengeHistoryConfiguration : IEntityTypeConfiguration<UserChallengeHistory>
    {
        public void Configure(EntityTypeBuilder<UserChallengeHistory> builder)
        {
            builder.HasOne(em => em.User)
                   .WithMany(u => u.UserChallengeHistories)
                   .HasForeignKey(em => em.UserId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(em => em.Challenge)
                   .WithMany(q => q.UserChallengeHistories)
                   .HasForeignKey(em => em.ChallengeId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
