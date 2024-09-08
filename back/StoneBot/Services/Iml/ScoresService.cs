using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class ScoresService : IScoresService
{
    // TODO move to config or relate to the level
    public const int MaxScoreCountPerDay = 10000;

    private readonly StoneBotDbContext _dbContext;

    public ScoresService(StoneBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Score> GetScoresByUser(long userId)
    {
        var score = await _dbContext.Scores
            .FirstAsync(x => x.UserId == userId);

        return score;
    }

    public async Task<Score> Click(long userId, int count)
    {

        var multiplier = await _dbContext.UserBoosters
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .Where(x => x.IsActive)
            .Select(x => x.Booster.CoinsCountPerClick)
            .SumAsync();

        multiplier = multiplier == 0 ? 1 : multiplier;
        count *= multiplier;

        return await AddConins(userId, count);
    }

    public async Task<Score> AddConins(long userId, int count)
    {
        var score = await _dbContext.Scores
            .FirstAsync(x => x.UserId == userId);

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

    public async Task<LeaderboardDto> GetLearboard(long userId, int limit, string? search)
    {
        var scoreQuery = _dbContext.Scores
            .Include(score => score.User)
            .AsNoTracking()
            .OrderByDescending(x => x.TotalScore);

        var scores = await scoreQuery
            .Take(limit)
            .ToListAsync();

        if (scores.All(x => x.UserId != userId))
        {
            scores = await scoreQuery.ToListAsync();
        }

        var userIds = scores.Select(x => x.UserId).ToList();

        var skins = await _dbContext.UserSkins
            .AsNoTracking()
            .Where(x => userIds.Contains(x.UserId))
            .ToListAsync();

        var leaders = scores.Select((score, index) => new LeaderDto
        {
            User = Map(score.User, skins),
            Order = index + 1,
            Score = score.TotalScore
        }).ToList();

        var currentUser = leaders.First(x => x.User.Id == userId);

        return new LeaderboardDto
        {
            CurrentUser = currentUser,
            Leaders = leaders.Where(l => string.IsNullOrEmpty(search) || l.User.Username.Contains(search, StringComparison.InvariantCultureIgnoreCase)).Take(limit).ToList()
        };
    }

    private static UserDto Map(User user, List<UserSkin> skins)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName,
            SkinId = skins.FirstOrDefault(x => x.UserId == user.Id)?.SkinId,
        };
    }
}