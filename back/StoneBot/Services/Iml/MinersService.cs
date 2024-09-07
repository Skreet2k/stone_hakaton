using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class MinersService : IMinersService
{
    private readonly StoneBotDbContext _dbContext;

    public MinersService(StoneBotDbContext dbContext)
    {
        _dbContext = dbContext;
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

        await _dbContext.SaveChangesAsync();

        return miner.Miner;
    }

    public Task<Miner> Add(Miner miner)
    {
        throw new NotImplementedException();
    }

    public Task Delete(long minerId)
    {
        throw new NotImplementedException();
    }
}