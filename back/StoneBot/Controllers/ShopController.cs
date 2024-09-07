using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("shop")]
public class ShopController : Controller
{
    private readonly IShopService _shopService;

    public ShopController(IShopService shopService)
    {
        _shopService = shopService;
    }

    [HttpPost("backgrounds/{backgroundId:long}")]
    public async Task BuyBackground(
        [FromRoute] long backgroundId,
        [FromQuery] [BindRequired] long userId)
    {
        await _shopService.BuyBackground(userId, backgroundId);
    }

    [HttpPost("boosters/{boosterId:long}")]
    public async Task BuyBooster(
        [FromRoute] long boosterId,
        [FromQuery] [BindRequired] long userId)
    {
        await _shopService.BuyBooster(userId, boosterId);
    }

    [HttpPost("skins/{skinId:long}")]
    public async Task BuySkin(
        [FromRoute] long skinId,
        [FromQuery] [BindRequired] long userId)
    {
        await _shopService.BuySkin(userId, skinId);
    }

    [HttpPost("miners/{minerId:long}")]
    public async Task BuyMiner(
        [FromRoute] long minerId,
        [FromQuery] [BindRequired] long userId)
    {
        await _shopService.BuyMiner(userId, minerId);
    }
}