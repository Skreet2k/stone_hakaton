using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StoneBot.Data;
using StoneBot.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

services.AddControllers();
services.AddMvc();
services.AddDbContext<StoneBotDbContext>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IScoresService, ScoresService>();
services.AddScoped<ISkinsService, SkinsService>();
services.AddScoped<IBackgroundsService, BackgroundsService>();
services.AddScoped<IMinersService, MinersService>();
services.AddScoped<IBoostersService, BoostersService>();
services.AddScoped<IShopService, ShopService>();

builder.Services.AddCors();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .WithOrigins("http://localhost:4200", "https://stone.onebranch.dev")
    .AllowAnyMethod()
    .AllowCredentials()
    .AllowAnyHeader());

app.UseRouting();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoneBotDbContext>();
    db.Database.Migrate();
}

app.Run();