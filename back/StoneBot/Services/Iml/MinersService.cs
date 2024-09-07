using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class MinersService : IMinersService
{
    private readonly StoneBotDbContext _dbContext;
    private readonly IScoresService _scoresService;

    public MinersService(
        StoneBotDbContext dbContext,
        IScoresService scoresService)
    {
        _dbContext = dbContext;
        _scoresService = scoresService;
    }

    public async Task<ActiveMinerDto?> GetCurrent(long userId)
    {
        var userMiner = await _dbContext.UserMiners
            .Include(userMiner => userMiner.Miner)
            .Where(x => x.UserId == userId)
            .Where(x => x.IsActive)
            .FirstOrDefaultAsync();

        if (userMiner == null)
        {
            return null;
        }

        var collected = CountCollecedCoins(userMiner);

        return new ActiveMinerDto
        {
            Miner = userMiner.Miner,
            StartedAt = userMiner.StartedAt,
            CollectedInMine = collected
        };
    }

    private static int CountCollecedCoins(UserMiner userMiner)
    {
        var workedTime = DateTime.UtcNow - userMiner.StartedAt;

        var times = (int) Math.Floor(workedTime / userMiner.Miner.TimeSpan);
        var collected = times * userMiner.Miner.CoinsCountPerTimeSpan;
        return collected;
    }

    public async Task<List<Miner>> Get(long? userId)
    {
        List<Miner> miners;
        if (userId.HasValue)
        {
            miners = await _dbContext.UserMiners
                .Where(x => x.UserId == userId)
                .Select(x => x.Miner)
                .ToListAsync();
        }
        else
        {
            miners = await _dbContext.Miners.ToListAsync();
        }

        return miners;
    }

    public async Task<Miner> Apply(long userId, long minerId)
    {
        var userMiners = await _dbContext.UserMiners
            .Where(x => x.UserId == userId)
            .Include(userMiner => userMiner.Miner)
            .ToListAsync();

        var miner = userMiners.FirstOrDefault(x => x.MinerId == minerId);
        if (miner == null)
        {
            throw new Exception($"User {userId} does not have a miner.");
        }

        userMiners.ForEach(x => x.IsActive = false);
        miner.IsActive = true;
        miner.StartedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();


        return miner.Miner;
    }

    public async Task Collect(long userId)
    {
        var userMiner = await _dbContext.UserMiners
            .Include(userMiner => userMiner.Miner)
            .Where(x => x.UserId == userId)
            .Where(x => x.IsActive)
            .FirstOrDefaultAsync();

        if (userMiner == null)
        {
            return;
        }

        var collected = CountCollecedCoins(userMiner);
        await _scoresService.AddConins(userId, collected);

        userMiner.StartedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Miner> Add(Miner miner)
    {
        await _dbContext.Miners.AddAsync(miner);
        await _dbContext.SaveChangesAsync();

        return miner;
    }

    public async Task Delete(long minerId)
    {
        var miner = await _dbContext.Miners.FindAsync(minerId);
        if (miner != null)
        {
            _dbContext.Miners.Remove(miner);
            await _dbContext.SaveChangesAsync();
        }
    }
}