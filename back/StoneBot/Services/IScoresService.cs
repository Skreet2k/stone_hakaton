using StoneBot.Domain;

namespace StoneBot.Services;

public interface IScoresService
{
    public Task<List<Score>> GetScoresByUser(long userId);
    public Task AddCoins(long userId, int count);
}