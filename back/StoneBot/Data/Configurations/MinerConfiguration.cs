using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneBot.Domain;

namespace StoneBot.Data.Configurations;

public class MinerConfiguration : IEntityTypeConfiguration<Miner>
{
    public void Configure(EntityTypeBuilder<Miner> builder)
    {
        builder.HasKey(x => x.Id);
    }
}