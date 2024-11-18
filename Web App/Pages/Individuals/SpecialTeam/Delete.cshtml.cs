using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Individuals.SpecialTeam
{
    public class DeleteModel : PageModel
    {
        private readonly SpecialTeamsRepository _specialTeamsRepository;
        private readonly GameRepository _gameRepository;

        [BindProperty]
        public SpecialTeams SpecialTeams { get; set; } = new();
        public Game? Game { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PlayerID { get; set; }

        public DeleteModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _specialTeamsRepository = new SpecialTeamsRepository(connectionString);
                _gameRepository = new GameRepository(connectionString);
            }
            else
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
        }

        public IActionResult OnGet(int playerId, int gameId)
        {
            PlayerID = playerId;
            SpecialTeams = _specialTeamsRepository.GetSpecialTeamsStatsByPlayerAndGame(playerId, gameId);
            if (SpecialTeams == null)
            {
                return NotFound();
            }

            Game = _gameRepository.GetGameById(gameId);
            return Page();
        }

        public IActionResult OnPost(int playerId, int gameId)
        {
            PlayerID = playerId;
            try
            {
                _specialTeamsRepository.DeleteSpecialTeamsStats(playerId, gameId);
                TempData["SuccessMessage"] = "Special Teams stats deleted successfully!";
                return RedirectToPage("/Individuals/Individual", new { playerId = PlayerID, activeTab = "specialteams" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting Special Teams stats: {ex.Message}";
                return RedirectToPage("/Individuals/Individual", new { playerId = PlayerID, activeTab = "specialteams" });
            }
        }
    }
}