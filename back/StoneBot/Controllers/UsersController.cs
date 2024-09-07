using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoneBot.Domain;
using StoneBot.Services;

namespace StoneBot.Controllers;

[ApiController]
[Route("users")]
[ApiExplorerSettings(GroupName = "Users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IScoresService _scoresService;

    public UsersController(IUserService userService, IScoresService scoresService)
    {
        _userService = userService;
        _scoresService = scoresService;
    }

    [HttpPut("init/{userId:long}")]
    public async Task<Score> Init([FromRoute] long userId)
    {
        await _userService.Init(userId);
        var score = await _scoresService.GetScoresByUser(userId);
        return score;
    }
}