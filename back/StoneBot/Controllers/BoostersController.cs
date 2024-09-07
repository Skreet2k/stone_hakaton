using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("boosters")]
[ApiExplorerSettings(GroupName = "Boosters")]
public class BoostersController : Controller
{
    private readonly IBoostersService _boostersService;

    public BoostersController(IBoostersService boostersService)
    {
        _boostersService = boostersService;
    }

    [HttpGet]
    public async Task<List<Booster>> GetBoosters([FromQuery] long? userId)
    {
        var boosters = await _boostersService.Get(userId);
        return boosters;
    }

    [HttpPut]
    public async Task<Booster> ApplyBooster(
        [FromQuery] [BindRequired] long userId,
        [FromQuery] [BindRequired] long boosterId)
    {
        var boosters = await _boostersService.Apply(userId, boosterId);
        return boosters;
    }
}