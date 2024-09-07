using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneBot.Domain;

namespace StoneBot.Data.Configurations;

public class ScoreConfiguration : IEntityTypeConfiguration<Score>
{
    public void Configure(EntityTypeBuilder<Score> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasOne<User>(x => x.User)
            .WithOne(x => x.Score);
    }
}