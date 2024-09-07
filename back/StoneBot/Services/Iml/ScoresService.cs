using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class ScoresService : IScoresService
{
    // TODO move to config or relate to the level
    public const int MaxScoreCountPerDay = 1000;

    private readonly StoneBotDbContext _dbContext;

    public ScoresService(StoneBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Score> GetScoresByUser(long userId)
    {
        var score = await _dbContext.Scores
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();

        return score ?? await CreateScore(userId);
    }

    public async Task<Score> Click(long userId, int count)
    {
        var score = await _dbContext.Scores
            .FirstOrDefaultAsync(x => x.UserId == userId);

        score ??= await CreateScore(userId);

        var multiplier = await _dbContext.UserBoosters
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .Where(x => x.IsActive)
            .Select(x => x.Booster.CoinsCountPerClick)
            .SumAsync();

        multiplier = multiplier == 0 ? 1 : multiplier;
        count *= multiplier;

        if (score.TodayScore + count > MaxScoreCountPerDay)
        {
            count = MaxScoreCountPerDay - score.TodayScore;
        }

        score.TodayScore += count;
        score.TotalScore += count;
        score.CurrentScore += count;

        await _dbContext.SaveChangesAsync();

        return score;
    }

    private async Task<Score> CreateScore(long userId)
    {
        var todayScore = new Score
        {
            UserId = userId,
        };

        await _dbContext.Scores.AddAsync(todayScore);
        await _dbContext.SaveChangesAsync();
        return todayScore;
    }

}