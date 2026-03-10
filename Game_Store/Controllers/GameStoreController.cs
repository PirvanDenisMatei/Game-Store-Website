using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameStoreController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GameStoreController> _logger;

        public GameStoreController(ILogger<GameStoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<GameStore> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new GameStore
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
