using Game_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameStoreController : ControllerBase
    {
        private readonly ILogger<GameStoreController> _logger;

        public GameStoreController(ILogger<GameStoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSomething")]
        public int Get(int id)
        {
            return 0;
        }
    }
}
