using StoneBot.Domain;

namespace StoneBot.Services;

public interface IBackgroundsService
{
    public Task<List<Background>> Get(long? userId);
    public Task<Background> Apply(long userId, long backgroundId);
}