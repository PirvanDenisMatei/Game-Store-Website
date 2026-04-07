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

        public GameStoreController(GamesService booksService) =>
        _gamesService = booksService;

        [HttpGet]
        public async Task<List<Game>> Get() => await _gamesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Game>> Get(string id)
        {
            var book = await _gamesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Game newBook)
        {
            await _gamesService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Game updatedBook)
        {
            var book = await _gamesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _gamesService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _gamesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _gamesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
