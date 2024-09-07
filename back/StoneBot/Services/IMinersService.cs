using StoneBot.Domain;

namespace StoneBot.Services;

public interface IMinersService
{
    Task<ActiveMinerDto?> GetCurrent(long userId);
    public Task<List<Miner>> Get(long? userId);
    public Task<Miner> Apply(long userId, long minerId);
    public Task Collect(long userId);

    public Task<Miner> Add(Miner miner);
    public Task Delete(long minerId);
}