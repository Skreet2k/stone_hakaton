using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class ScoresService : IScoresService
{
    // TODO move to config or relate to the level
    private const int MaxScoreCountPerDay = 1000;

    private readonly StoneBotDbContext _dbContext;

    public ScoresService(StoneBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Score>> GetScoresByUser(long userId)
    {
        var scores = await _dbContext.Scores
            .Where(x => x.UserId == userId)
            .ToListAsync();

        var today = Today();
        if (scores.All(x => x.Date != today))
        {
            var todayScore = await CreateTodayScore(userId, today);
            scores.Add(todayScore);
        }

        return scores;
    }

    public async Task AddCoins(long userId, int count)
    {
        var today = Today();
        var todayScore = await _dbContext.Scores
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Date == today);

        if (todayScore == null)
        {
            todayScore = await CreateTodayScore(userId, today);
        }

        todayScore.Count += count;
        await _dbContext.SaveChangesAsync();
    }

    private async Task<Score> CreateTodayScore(long userId, DateOnly today)
    {
        var todayScore = new Score
        {
            Date = today,
            UserId = userId,
            MaxCount = MaxScoreCountPerDay
        };
        await _dbContext.Scores.AddAsync(todayScore);
        await _dbContext.SaveChangesAsync();
        return todayScore;
    }

    private static DateOnly Today() => DateOnly.FromDateTime(DateTime.Today);
}