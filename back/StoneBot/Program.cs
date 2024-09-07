using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddControllers();
services.AddDbContext<StoneBotDbContext>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IScoresService, ScoresService>();
services.AddScoped<ISkinsService, SkinsService>();
services.AddScoped<IBackgroundsService, BackgroundsService>();
services.AddScoped<IMinersService, MinersService>();
services.AddScoped<IBoostersService, BoostersService>();
services.AddScoped<IShopService, ShopService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoneBotDbContext>();
    db.Database.Migrate();
}

app.Run();