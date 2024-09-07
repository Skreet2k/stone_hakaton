using Microsoft.EntityFrameworkCore;
using StoneBot.Domain;

namespace StoneBot.Data;

public class StoneBotDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Skin> Skins { get; set; }
    public DbSet<UserSkin> UserSkins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite("Data Source=StoneBot.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // users
        var userBuilder = modelBuilder.Entity<User>();
        userBuilder.HasKey(x => x.Id);

        // scores
        var scoreBuilder = modelBuilder.Entity<Score>();
        scoreBuilder.HasKey(x => x.Id);
        scoreBuilder
            .HasOne<User>(x => x.User)
            .WithMany(x => x.Scores);

        // skins
        var skinBuilder = modelBuilder.Entity<Skin>();
        skinBuilder.HasKey(x => x.Id);

        // user skins
        var userSkinBuilder = modelBuilder.Entity<UserSkin>();
        userSkinBuilder.HasKey(x => new { x.UserId, x.SkinId });
        userSkinBuilder
            .HasOne<User>(x => x.User)
            .WithMany();
        userSkinBuilder
            .HasOne<Skin>(x => x.Skin)
            .WithMany();
    }
}