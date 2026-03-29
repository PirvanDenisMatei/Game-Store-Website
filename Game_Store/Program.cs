using Game_Store.Models;
using Game_Store.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<GameStoreDatabaseSettings>(builder.Configuration.GetSection("GameStoreDatabase"));
builder.Services.AddSingleton<GamesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (ctx, next) =>
{
    Console.Write("Czesc!\n");
    await next();
    Console.Write("Do widzenia!\n");
});

app.MapControllers();

//app.Run(async (ctx) =>
//{
//    Console.Write("Kocham cie!\n");
//    await ctx.Response.WriteAsync("Done!");
//});
app.Run();