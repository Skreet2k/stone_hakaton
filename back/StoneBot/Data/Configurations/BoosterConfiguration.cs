using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneBot.Domain;

namespace StoneBot.Data.Configurations;

public class BoosterConfiguration : IEntityTypeConfiguration<Booster>
{
    public void Configure(EntityTypeBuilder<Booster> builder)
    {
        builder.HasKey(x => x.Id);
    }
}