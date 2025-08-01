using its.gamify.domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.infras.FluentApis;

public class RoomConfiugration : IEntityTypeConfiguration<Room>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Room> builder)
    {
        builder.HasOne(r => r.Challenge)
                   .WithMany(c => c.Rooms)
                   .HasForeignKey(r => r.ChallengeId)
                   .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.HostUser)
        .WithMany()
        .HasForeignKey(r => r.HostUserId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.OpponentUser)
            .WithMany()
            .HasForeignKey(r => r.OpponentUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}