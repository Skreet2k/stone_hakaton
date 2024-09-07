using Microsoft.AspNetCore.Mvc;
using StoneBot.Contracts;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IScoresService _scoresService;

    public UsersController(IUserService userService, IScoresService scoresService)
    {
        _userService = userService;
        _scoresService = scoresService;
    }

    [HttpPost("init")]
    public async Task<GetUserScoreResponse> Init(
        [FromBody] InitUserRequest request)
    {
        await _userService.Init(request.UserId, request.Username, request.FirstName, request.LastName);
        var score = await _scoresService.GetScoresByUser(request.UserId);

        return new GetUserScoreResponse
        {
            TotalScore = score.TotalScore,
            TodayScore = score.TodayScore,
            CurrentScore = score.CurrentScore,
            TodayLimit = ScoresService.MaxScoreCountPerDay
        };
    }
}