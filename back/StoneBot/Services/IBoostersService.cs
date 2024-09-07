using StoneBot.Domain;

namespace StoneBot.Services;

public interface IBoostersService
{
    public Task<List<Booster>> Get(long? userId);
    public Task<Booster> Apply(long userId, long boosterId);
}