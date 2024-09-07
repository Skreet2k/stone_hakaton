using StoneBot.Domain;

namespace StoneBot.Services;

public interface IMinersService
{
    public Task<List<Miner>> Get(long? userId);
    public Task<Miner> Apply(long userId, long minerId);
}