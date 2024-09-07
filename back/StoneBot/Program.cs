using Microsoft.AspNetCore.Mvc;
using StoneBot.Contracts;
using StoneBot.Data;
using StoneBot.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddDbContext<StoneBotDbContext>();
services.AddScoped<IScoresService, ScoresService>();
services.AddScoped<ISkinsService, SkinsService>();

var app = builder.Build();

app.MapPost("/score", async (
    [FromBody] GetUserScoreRequest request,
    [FromServices] IScoresService service) =>
{
    var scores = await service.GetScoresByUser(request.UserId);

    var todayScore = scores.MaxBy(x => x.Date)!;
    return new GetUserScoreResponse
    {
        TotalScore = scores.Sum(x => x.Count),
        TodayScore = todayScore.Count,
        TodayLimit = todayScore.MaxCount
    };
}).WithDescription("Get users score");

app.MapPut("/score", async (
    [FromBody] AddCoinsRequest request,
    [FromServices] IScoresService service) =>
{
    await service.AddCoins(request.UserId, request.Count);
}).WithDescription("Add coins to today's score");

app.MapPost("/skins", async (
    [FromBody] GetSkinsRequest request,
    [FromServices] ISkinsService service) =>
{
    await service.GetSkins(request.UserId);
}).WithDescription("Get skins by filters");

app.Run();