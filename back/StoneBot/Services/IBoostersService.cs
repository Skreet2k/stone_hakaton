using StoneBot.Domain;

namespace StoneBot.Services;

public interface IBoostersService
{
    public Task<Booster?> GetCurrent(long userId);
    public Task<List<Booster>> Get(long? userId);
    public Task<Booster> Apply(long userId, long boosterId);

    public Task<Booster> Add(Booster booster);
    public Task Delete(long boosterId);
}