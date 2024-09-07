using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneBot.Domain;

namespace StoneBot.Data.Configurations;

public class UserMinerConfiguration : IEntityTypeConfiguration<UserMiner>
{
    public void Configure(EntityTypeBuilder<UserMiner> builder)
    {
        builder.HasKey(x => new { x.UserId, x.MinerId });
        builder
            .HasOne<User>(x => x.User)
            .WithMany(x => x.Miners);
        builder
            .HasOne<Miner>(x => x.Miner)
            .WithMany();
    }
}