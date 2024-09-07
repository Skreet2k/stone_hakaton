using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class SkinsService : ISkinsService
{
    private readonly StoneBotDbContext _dbContext;

    public SkinsService(StoneBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Skin>> Get(long? userId)
    {
        List<Skin> skins;
        if (userId.HasValue)
        {
            skins = await _dbContext.UserSkins
                .Where(x => x.UserId == userId)
                .Select(x => x.Skin)
                .ToListAsync();
        }
        else
        {
            skins = await _dbContext.Skins.ToListAsync();
        }

        return skins;
    }

    public async Task<Skin> Apply(long userId, long skinId)
    {
        var userSkins = await _dbContext.UserSkins
            .Where(x => x.UserId == userId)
            .Include(userSkin => userSkin.Skin)
            .ToListAsync();

        var skin = userSkins.FirstOrDefault(x => x.SkinId == skinId);
        if (skin == null)
        {
            throw new Exception($"User {userId} does not have a skin.");
        }

        userSkins.ForEach(x => x.IsActive = false);
        skin.IsActive = true;

        await _dbContext.SaveChangesAsync();

        return skin.Skin;
    }
}