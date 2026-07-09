using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Game_Store.Models;
using Game_Store.Services;

namespace Game_Store.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly GamesService _gamesService;

        public Game? game { get; set; }

        public DetailsModel(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        public async Task OnGetAsync(string id)
        {
            game = await _gamesService.GetAsync(id);
        }
    }
}