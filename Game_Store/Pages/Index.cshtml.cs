using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Game_Store.Models;
using Game_Store.Services;

namespace Game_Store.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GamesService _gamesService;

        public List<Game> Games { get; private set; } = [];

        public IndexModel(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        public async Task OnGetAsync()
        {
            Games = await _gamesService.GetAsync();
        }
    }
}
