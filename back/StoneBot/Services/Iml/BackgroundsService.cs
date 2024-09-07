using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class BackgroundsService : IBackgroundsService
{
    private readonly StoneBotDbContext _dbContext;

    public BackgroundsService(StoneBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Background>> Get(long? userId)
    {
        List<Background> backgrounds;
        if (userId.HasValue)
        {
            backgrounds = await _dbContext.UserBackgrounds
                .Where(x => x.UserId == userId)
                .Select(x => x.Background)
                .ToListAsync();
        }
        else
        {
            backgrounds = await _dbContext.Backgrounds.ToListAsync();
        }

        return backgrounds;
    }

    public async Task<Background> Apply(long userId, long backgroundId)
    {
        var userBackgrounds = await _dbContext.UserBackgrounds
            .Where(x => x.UserId == userId)
            .Include(userBackground => userBackground.Background)
            .ToListAsync();

        var background = userBackgrounds.FirstOrDefault(x => x.BackgroundId == backgroundId);
        if (background == null)
        {
            throw new Exception($"User {userId} does not have a background.");
        }

        userBackgrounds.ForEach(x => x.IsActive = false);
        background.IsActive = true;

        await _dbContext.SaveChangesAsync();

        return background.Background;
    }
}