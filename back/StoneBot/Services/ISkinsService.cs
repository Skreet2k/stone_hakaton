using StoneBot.Domain;

namespace StoneBot.Services;

public interface ISkinsService
{
    public Task<List<Skin>> GetSkins(long? userId);
}