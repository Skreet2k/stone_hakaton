using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Domain;

namespace StoneBot.Services;

public class ShopService : IShopService
{
    private readonly StoneBotDbContext _dbContext;
    private readonly IMinersService _minersService;
    private readonly IBoostersService _boostersService;
    private readonly IBackgroundsService _backgroundsService;
    private readonly ISkinsService _skinsService;

    public ShopService(
        StoneBotDbContext dbContext,
        IMinersService minersService,
        IBoostersService boostersService,
        IBackgroundsService backgroundsService,
        ISkinsService skinsService)
    {
        _dbContext = dbContext;
        _minersService = minersService;
        _boostersService = boostersService;
        _backgroundsService = backgroundsService;
        _skinsService = skinsService;
    }

    public async Task BuySkin(long userId, long itemId)
    {
        var score = await _dbContext.Scores
            .FirstAsync(x => x.UserId == userId);

        var item = await _dbContext.Skins
            .AsNoTracking()
            .FirstAsync(x => x.Id == itemId);

        var userItems = await _dbContext.UserSkins
            .Where(x => x.UserId == userId)
            .ToListAsync();

        if (userItems.Any(x => x.SkinId == itemId))
        {
            return;
        }

        if (score.CurrentScore < item.Price)
        {
            throw new Exception("You don't have enough score to buy this skin!");
        }

        score.CurrentScore -= item.Price;

        var userItem = new UserSkin
        {
            UserId = userId,
            SkinId = itemId,
            IsActive = true
        };

        await _dbContext.UserSkins.AddAsync(userItem);
        await _dbContext.SaveChangesAsync();

        await _skinsService.Apply(userId, itemId);
    }

    public async Task BuyBackground(long userId, long itemId)
    {
        var score = await _dbContext.Scores
            .FirstAsync(x => x.UserId == userId);

        var item = await _dbContext.Backgrounds
            .AsNoTracking()
            .FirstAsync(x => x.Id == itemId);

        if (score.CurrentScore < item.Price)
        {
            throw new Exception("You don't have enough score to buy this background!");
        }

        score.CurrentScore -= item.Price;

        var userItem = new UserSkin
        {
            UserId = userId,
            SkinId = itemId
        };

        await _dbContext.UserSkins.AddAsync(userItem);
        await _dbContext.SaveChangesAsync();

        await _backgroundsService.Apply(userId, itemId);
    }

    public async Task BuyBooster(long userId, long itemId)
    {
        var score = await _dbContext.Scores
            .FirstAsync(x => x.UserId == userId);

        var item = await _dbContext.Boosters
            .AsNoTracking()
            .FirstAsync(x => x.Id == itemId);

        if (score.CurrentScore < item.Price)
        {
            throw new Exception("You don't have enough score to buy this booster!");
        }

        score.CurrentScore -= item.Price;

        var userItem = new UserBooster
        {
            UserId = userId,
            BoosterId = itemId
        };

        await _dbContext.UserBoosters.AddAsync(userItem);
        await _dbContext.SaveChangesAsync();

        await _boostersService.Apply(userId, itemId);
    }

    public async Task BuyMiner(long userId, long itemId)
    {
        var score = await _dbContext.Scores
            .FirstAsync(x => x.UserId == userId);

        var item = await _dbContext.Miners
            .AsNoTracking()
            .FirstAsync(x => x.Id == itemId);

        if (score.CurrentScore < item.Price)
        {
            throw new Exception("You don't have enough score to buy this miner!");
        }

        score.CurrentScore -= item.Price;

        var userItem = new UserMiner
        {
            UserId = userId,
            MinerId = itemId
        };

        await _dbContext.UserMiners.AddAsync(userItem);
        await _dbContext.SaveChangesAsync();

        await _minersService.Apply(userId, itemId);
    }
}