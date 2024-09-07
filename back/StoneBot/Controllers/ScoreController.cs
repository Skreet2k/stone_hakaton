using Microsoft.AspNetCore.Mvc;
using StoneBot.Contracts;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("scores")]
[ApiExplorerSettings(GroupName = "Scores")]
public class ScoreController : Controller
{
    private readonly IScoresService _scoresService;

    public ScoreController(IScoresService scoresService)
    {
        _scoresService = scoresService;
    }

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

    [HttpPut("click")]
    public async Task<GetUserScoreResponse> Click([FromBody] ClickRequest request)
    {
        var count = request.Count is null or 0
            ? 1
            : request.Count.Value;

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