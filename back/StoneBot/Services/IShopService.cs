namespace StoneBot.Services;

public interface IShopService
{
    public Task BuySkin(long userId, long itemId);
    public Task BuyBackground(long userId, long itemId);
    public Task BuyBooster(long userId, long itemId);
    public Task BuyMiner(long userId, long itemId);
}