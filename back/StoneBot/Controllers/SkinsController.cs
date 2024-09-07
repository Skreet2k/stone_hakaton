using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("skins")]
public class SkinsController : Controller
{
    private readonly ISkinsService _skinsService;

    public SkinsController(ISkinsService skinsService)
    {
        _skinsService = skinsService;
    }

    /// <summary>
    ///     Get Current Skin
    /// </summary>
    /// <param name="userId"> User ID</param>
    /// <returns> Current User Skin</returns>
    [HttpGet("current")]
    public async Task<Skin?> GetCurrent([FromQuery] long userId)
    {
        var skin = await _skinsService.GetCurrent(userId);
        return skin;
    }

    /// <summary>
    ///     Get Skins
    /// </summary>
    /// <param name="userId"> User ID. Optional</param>
    /// <returns>Skins</returns>
    [HttpGet]
    public async Task<List<Skin>> GetSkins([FromQuery] long? userId)
    {
        var skins = await _skinsService.Get(userId);

        return skins;
    }

    /// <summary>
    ///     Apply Skin to User
    /// </summary>
    /// <param name="userId"> User ID </param>
    /// <param name="skinId"> Skin ID</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<Skin> ApplySkin(
        [FromQuery] [BindRequired] long userId,
        [FromQuery] [BindRequired] long skinId)
    {
        var skins = await _skinsService.Apply(userId, skinId);
        return skins;
    }

    /// <summary>
    ///     Admin. Create Skin
    /// </summary>
    /// <param name="skin"> Skin </param>
    /// <returns> Skin </returns>
    [HttpPost]
    public async Task<Skin> AddBackground([FromBody] Skin skin)
    {
        skin = await _skinsService.Add(skin);
        return skin;
    }

    /// <summary>
    ///     Admin. Delete Skin by ID
    /// </summary>
    /// <param name="skinId"> Skin ID </param>
    [HttpDelete("{skinId:long}")]
    public async Task Delete([FromRoute] long skinId)
    {
        await _skinsService.Delete(skinId);
    }
}