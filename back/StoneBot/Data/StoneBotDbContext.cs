using Microsoft.EntityFrameworkCore;
using StoneBot.Domain;

namespace StoneBot.Data;

public class StoneBotDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Skin> Skins { get; set; }
    public DbSet<Background> Backgrounds { get; set; }
    public DbSet<Booster> Boosters { get; set; }
    public DbSet<Miner> Miners { get; set; }
    public DbSet<UserSkin> UserSkins { get; set; }
    public DbSet<UserBackground> UserBackgrounds { get; set; }
    public DbSet<UserBooster> UserBoosters { get; set; }
    public DbSet<UserMiner> UserMiners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite("Data Source=StoneBot.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}