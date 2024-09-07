using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("skins")]
[ApiExplorerSettings(GroupName = "Skins")]
public class SkinsController : Controller
{
    private readonly ISkinsService _skinsService;

    public SkinsController(ISkinsService skinsService)
    {
        _skinsService = skinsService;
    }

    [HttpGet]
    public async Task<List<Skin>> GetSkins([FromQuery] long? userId)
    {
        var skins = await _skinsService.Get(userId);

        return skins;
    }

    [HttpPut]
    public async Task<Skin> ApplySkin(
        [FromQuery] [BindRequired] long userId,
        [FromQuery] [BindRequired] long skinId)
    {
        var skins = await _skinsService.Apply(userId, skinId);
        return skins;
    }
}