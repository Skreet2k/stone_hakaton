using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("miners")]
public class MinersController : Controller
{
    private readonly IMinersService _minersService;

    public MinersController(IMinersService minersService)
    {
        _minersService = minersService;
    }

    [HttpGet]
    public async Task<List<Miner>> GetMiners([FromQuery] long? userId)
    {
        var miners = await _minersService.Get(userId);
        return miners;
    }

    [HttpPut]
    public async Task<Miner> ApplyMiner(
        [FromQuery] [BindRequired] long userId,
        [FromQuery] [BindRequired] long minerId)
    {
        var miners = await _minersService.Apply(userId, minerId);
        return miners;
    }
}