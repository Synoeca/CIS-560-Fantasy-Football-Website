using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_App.Pages.Individuals.SpecialTeam
{
    public class EditModel : PageModel
    {
        private readonly SpecialTeamsRepository _specialTeamsRepository;
        private readonly GameRepository _gameRepository;

        [BindProperty]
        public SpecialTeams? SpecialTeams { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int PlayerID { get; set; }

        public Game? Game { get; set; }

        public EditModel(IConfiguration configuration)
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
            if (!ModelState.IsValid)
            {
                Game = _gameRepository.GetGameById(gameId);
                return Page();
            }

            try
            {
                _specialTeamsRepository.UpdateSpecialTeamsStats(SpecialTeams);
                TempData["SuccessMessage"] = "Special Teams stats updated successfully!";
                return RedirectToPage("/Individuals/Individual", new { playerId = PlayerID, activeTab = "specialteams" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating Special Teams stats: {ex.Message}");
                Game = _gameRepository.GetGameById(gameId);
                return Page();
            }
        }
    }
}