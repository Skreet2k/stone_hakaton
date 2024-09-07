using StoneBot.Domain;

namespace StoneBot.Services;

public interface IScoresService
{
    Task<Score> GetScoresByUser(long userId);

    Task<Score>  Click(long userId, int count);
}