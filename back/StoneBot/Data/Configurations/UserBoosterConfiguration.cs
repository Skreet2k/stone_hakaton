using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneBot.Domain;

namespace StoneBot.Data.Configurations;

public class UserBoosterConfiguration : IEntityTypeConfiguration<UserBooster>
{
    public void Configure(EntityTypeBuilder<UserBooster> builder)
    {
        builder.HasKey(x => new { x.UserId, x.BoosterId });
        builder
            .HasOne<User>(x => x.User)
            .WithMany(x => x.Boosters);
        builder
            .HasOne<Booster>(x => x.Booster)
            .WithMany();
    }
}