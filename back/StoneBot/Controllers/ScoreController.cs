using Microsoft.AspNetCore.Mvc;
using StoneBot.Contracts;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("scores")]
public class ScoreController : Controller
{
    private readonly IScoresService _scoresService;

    public ScoreController(IScoresService scoresService)
    {
        _scoresService = scoresService;
    }

    /// <summary>
    ///     Get Leaderboard
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="limit"> Leaderboard size. By default = 10</param>
    /// <returns> Leaderboard </returns>
    [HttpGet("leaderboard")]
    public async Task<LeaderboardDto> GetLeaderboard(
        [FromQuery] long userId,
        [FromQuery] int limit = 10)
    {
        var leaderboard = await _scoresService.GetLearboard(userId, limit);
        return leaderboard;
    }

    /// <summary>
    ///     Get Score by User ID
    /// </summary>
    /// <param name="userId"> User ID </param>
    /// <returns> User Score </returns>
    [HttpGet("{userId:long}")]
    public async Task<GetUserScoreResponse> GetUserScore(long userId)
    {
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
    ///     Make a click
    /// </summary>
    /// <param name="request"> Request Parameters </param>
    /// <returns> User Score</returns>
    [HttpPut("click")]
    public async Task<GetUserScoreResponse> Click([FromBody] ClickRequest request)
    {
        var count = request.Count is 0 ? 1 : request.Count;

        var score = await _scoresService.Click(request.UserId, count);

        return new GetUserScoreResponse
        {
            TotalScore = score.TotalScore,
            TodayScore = score.TodayScore,
            CurrentScore = score.CurrentScore,
            TodayLimit = ScoresService.MaxScoreCountPerDay
        };
    }
}