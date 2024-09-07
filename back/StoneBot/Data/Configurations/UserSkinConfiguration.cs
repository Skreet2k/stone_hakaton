using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneBot.Domain;

namespace StoneBot.Data.Configurations;

public class UserSkinConfiguration : IEntityTypeConfiguration<UserSkin>
{
    public void Configure(EntityTypeBuilder<UserSkin> builder)
    {
        builder.HasKey(x => new { x.UserId, x.SkinId });
        builder
            .HasOne<User>(x => x.User)
            .WithMany(x => x.Skins);
        builder
            .HasOne<Skin>(x => x.Skin)
            .WithMany();
    }
}