using StoneBot.Domain;

namespace StoneBot.Services;

public interface IMinersService
{
    public Task<List<Miner>> Get(long? userId);
    public Task<Miner> Apply(long userId, long minerId);

    public Task<Miner> Add(Miner miner);
    public Task Delete(long minerId);
}