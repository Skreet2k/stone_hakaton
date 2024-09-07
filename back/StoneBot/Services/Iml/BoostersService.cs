using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class BoostersService : IBoostersService
{
    private readonly StoneBotDbContext _dbContext;

    public BoostersService(StoneBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Booster>> Get(long? userId)
    {
        List<Booster> boosters;
        if (userId.HasValue)
        {
            boosters = await _dbContext.UserBoosters
                .Where(x => x.UserId == userId)
                .Select(x => x.Booster)
                .ToListAsync();
        }
        else
        {
            boosters = await _dbContext.Boosters.ToListAsync();
        }

        return boosters;
    }

    public async Task<Booster> Apply(long userId, long boosterId)
    {
        var userBoosters = await _dbContext.UserBoosters
            .Where(x => x.UserId == userId)
            .Include(userBooster => userBooster.Booster)
            .ToListAsync();

        var booster = userBoosters.FirstOrDefault(x => x.BoosterId == boosterId);
        if (booster == null)
        {
            throw new Exception($"User {userId} does not have a booster.");
        }

        booster.IsActive = true;

        await _dbContext.SaveChangesAsync();

        return booster.Booster;
    }

    public Task<Booster> Add(Booster booster)
    {
        throw new NotImplementedException();
    }

    public Task Delete(long boosterId)
    {
        throw new NotImplementedException();
    }
}