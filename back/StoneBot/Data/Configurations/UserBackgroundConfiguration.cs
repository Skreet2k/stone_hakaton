using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneBot.Domain;

namespace StoneBot.Data.Configurations;

public class UserBackgroundConfiguration : IEntityTypeConfiguration<UserBackground>
{
    public void Configure(EntityTypeBuilder<UserBackground> builder)
    {
        builder.HasKey(x => new { x.UserId, x.BackgroundId });
        builder
            .HasOne<User>(x => x.User)
            .WithMany(x => x.Backgrounds);
        builder
            .HasOne<Background>(x => x.Background)
            .WithMany();
    }
}