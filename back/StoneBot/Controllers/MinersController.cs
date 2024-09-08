using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Contracts;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("miners")]
public class MinersController : Controller
{
    private readonly IMinersService _minersService;
    private readonly IScoresService _scoresService;

    public MinersController(
        IMinersService minersService,
        IScoresService scoresService)
    {
        _minersService = minersService;
        _scoresService = scoresService;
    }

    /// <summary>
    ///     Get Current Miner
    /// </summary>
    /// <param name="userId"> User ID</param>
    /// <returns> Current User Miner</returns>
    [HttpGet("current")]
    public async Task<ActiveMinerDto?> GetCurrent([FromQuery] long userId)
    {
        var miner = await _minersService.GetCurrent(userId);
        return miner;
    }

    /// <summary>
    ///     Get Miners
    /// </summary>
    /// <param name="userId"> User ID. Optional. </param>
    /// <returns> Miner list </returns>
    [HttpGet]
    public async Task<List<Miner>> GetMiners([FromQuery] long? userId)
    {
        var miners = await _minersService.Get(userId);
        return miners;
    }

    /// <summary>
    ///     Start miner to user.
    /// </summary>
    /// <param name="userId"> User ID.</param>
    /// <param name="minerId"> Miner ID. </param>
    /// <returns> Current Miner. </returns>
    [HttpPut]
    public async Task<Miner> ApplyMiner(
        [FromQuery] [BindRequired] long userId,
        [FromQuery] [BindRequired] long minerId)
    {
        var miners = await _minersService.Apply(userId, minerId);
        return miners;
    }

    /// <summary>
    ///     Collect coins from current miner.
    /// </summary>
    /// <param name="userId"> User ID.</param>
    [HttpPut("collect")]
    public async Task<GetUserScoreResponse> Collect(
        [FromQuery] [BindRequired] long userId)
    {
        await _minersService.Collect(userId);
        var score = await _scoresService.GetScoresByUser(userId);
        return new GetUserScoreResponse
        {
            TotalScore = score.TotalScore,
            TodayScore = score.TodayScore,
            CurrentScore = score.CurrentScore,
            TodayLimit = ScoresService.MaxScoreCountPerDay
        };
    }

    /// <summary>
    ///     Admin. Create Miner
    /// </summary>
    /// <param name="miner"> Miner </param>
    /// <returns> Miner </returns>
    [HttpPost]
    public async Task<Miner> AddBackground([FromBody] Miner miner)
    {
        miner = await _minersService.Add(miner);
        return miner;
    }

    /// <summary>
    ///     Admin. Delete Miner by ID
    /// </summary>
    /// <param name="minerId"> Miner ID </param>
    [HttpDelete("{minerId:long}")]
    public async Task Delete([FromRoute] long minerId)
    {
        await _minersService.Delete(minerId);
    }
}