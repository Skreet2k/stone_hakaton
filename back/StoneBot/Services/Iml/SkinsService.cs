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
    
    public async Task<List<Skin>> GetSkins(long? userId)
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
}