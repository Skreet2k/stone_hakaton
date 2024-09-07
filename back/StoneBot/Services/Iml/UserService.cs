using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class UserService : IUserService
{
    private readonly StoneBotDbContext _dbContext;

    public UserService(StoneBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Init(long userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);

        if (user != null)
        {
            return;
        }

        user = new User
        {
            Id = userId,
        };

        var score = new Score
        {
            UserId = userId,
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.Scores.AddAsync(score);

        await _dbContext.SaveChangesAsync();
    }
}