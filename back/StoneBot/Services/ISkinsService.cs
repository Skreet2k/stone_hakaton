using StoneBot.Domain;

namespace StoneBot.Services;

public interface ISkinsService
{
    public Task<Skin?> GetCurrent(long userId);
    public Task<List<Skin>> Get(long? userId);
    public Task<Skin> Apply(long userId, long skinId);

    public Task<Skin> Add(Skin skin);
    public Task Delete(long skinId);
}