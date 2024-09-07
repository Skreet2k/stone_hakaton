using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("backgrounds")]
public class BackgroundsController : Controller
{
    private readonly IBackgroundsService _backgroundsService;

    public BackgroundsController(IBackgroundsService backgroundsService)
    {
        _backgroundsService = backgroundsService;
    }


    /// <summary>
    ///     Get backgrounds
    /// </summary>
    /// <param name="userId"> User ID. Optional</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<Background>> GetBackgrounds([FromQuery] long? userId)
    {
        var backgrounds = await _backgroundsService.Get(userId);
        return backgrounds;
    }

    [HttpPut]
    public async Task<Background> ApplyBackground(
        [FromQuery] [BindRequired] long userId,
        [FromQuery] [BindRequired] long backgroundId)
    {
        var backgrounds = await _backgroundsService.Apply(userId, backgroundId);
        return backgrounds;
    }

    [HttpPost]
    public async Task<Background> AddBackground([FromBody] Background background)
    {
        background = await _backgroundsService.Add(background);
        return background;
    }

    [HttpDelete("{backgroundId:long}")]
    public async Task Delete([FromRoute] long backgroundId)
    {
        await _backgroundsService.Delete(backgroundId);
    }
}