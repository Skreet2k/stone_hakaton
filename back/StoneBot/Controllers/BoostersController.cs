using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("boosters")]
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


    /// <summary>
    ///     Admin. Create Booster
    /// </summary>
    /// <param name="booster"> Booster </param>
    /// <returns> Booster </returns>
    [HttpPost]
    public async Task<Booster> AddBackground([FromBody] Booster booster)
    {
        booster = await _boostersService.Add(booster);
        return booster;
    }

    /// <summary>
    ///     Admin. Delete Booster by ID
    /// </summary>
    /// <param name="boosterId"> Booster ID </param>
    [HttpDelete("{boosterId:long}")]
    public async Task Delete([FromRoute] long boosterId)
    {
        await _boostersService.Delete(boosterId);
    }
}