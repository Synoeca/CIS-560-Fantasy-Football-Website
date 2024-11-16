using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly GameRepository _gameRepository;
        private readonly TeamRepository _teamRepository;

        [BindProperty]
        public Game Game { get; set; } = new();
        public string HomeTeamName { get; set; } = string.Empty;
        public string AwayTeamName { get; set; } = string.Empty;

        public DeleteModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _gameRepository = new GameRepository(connectionString);
                _teamRepository = new TeamRepository(connectionString);
            }
            else
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
        }

        public IActionResult OnGet(int id)
        {
            Game = _gameRepository.GetGameById(id) ?? new Game();
            if (Game.GameID == 0)
            {
                return NotFound();
            }

            HomeTeamName = _teamRepository.GetTeamNameById(Convert.ToInt32(Game.HomeTeam));
            AwayTeamName = _teamRepository.GetTeamNameById(Convert.ToInt32(Game.AwayTeam));
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Game.GameID == 0)
            {
                return NotFound();
            }

            try
            {
                _gameRepository.DeleteGame(Game.GameID);
                TempData["SuccessMessage"] = "Game deleted successfully!";
                return RedirectToPage("./Games");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting game: {ex.Message}";
                return RedirectToPage("./Games");
            }
        }
    }
}