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

    public async Task<Booster?> GetCurrent(long userId)
    {
        var booster = await _dbContext.UserBoosters
            .Where(x => x.UserId == userId)
            .Where(x => x.IsActive)
            .Select(x => x.Booster)
            .FirstOrDefaultAsync();

        return booster;
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

    public async Task<Booster> Add(Booster booster)
    {
        await _dbContext.Boosters.AddAsync(booster);
        await _dbContext.SaveChangesAsync();

        return booster;
    }

    public async Task Delete(long boosterId)
    {
        var booster = await _dbContext.Boosters.FindAsync(boosterId);
        if (booster != null)
        {
            _dbContext.Boosters.Remove(booster);
            await _dbContext.SaveChangesAsync();
        }
    }
}