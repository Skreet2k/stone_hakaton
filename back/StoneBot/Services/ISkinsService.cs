using StoneBot.Domain;

namespace StoneBot.Services;

public interface ISkinsService
{
    public Task<List<Skin>> Get(long? userId);
    public Task<Skin> Apply(long userId, long skinId);
}