using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneBot.Domain;

namespace StoneBot.Data.Configurations;

public class BackgroundConfiguration : IEntityTypeConfiguration<Background>
{
    public void Configure(EntityTypeBuilder<Background> builder)
    {
        builder.HasKey(x => x.Id);
    }
}