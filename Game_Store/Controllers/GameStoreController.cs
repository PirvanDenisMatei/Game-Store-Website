using Game_Store.Models;
using Game_Store.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameStoreController : ControllerBase
    {
        private readonly GamesService _gamesService;

        public GameStoreController(GamesService gamesService) =>
        _gamesService = gamesService;

        [HttpGet]
        public async Task<List<Game>> Get() => await _gamesService.GetAsync();

        [HttpGet("{name}")]
        public async Task<ActionResult<Game>> GetByName(string name)
        {
            var game = await _gamesService.GetAsyncName(name);

            if (game is null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Game>> Get(string id)
        {
            var game = await _gamesService.GetAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Game newGame)
        {
            await _gamesService.CreateAsync(newGame);

            return CreatedAtAction(nameof(Get), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Game updatedGame)
        {
            var book = await _gamesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedGame.Id = book.Id;

            await _gamesService.UpdateAsync(id, updatedGame);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var game = await _gamesService.GetAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            await _gamesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
