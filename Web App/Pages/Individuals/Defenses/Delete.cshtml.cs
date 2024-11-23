using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Web_App.Pages.Individuals.Defenses
{
    public class DeleteModel : PageModel
    {
        private readonly DefenseRepository _defenseRepository;
        private readonly GameRepository _gameRepository;

        [BindProperty]
        public Defense? Defense { get; set; } = new();
        public Game? Game { get; set; }

        [BindProperty(SupportsGet = true)]  // Add this to ensure PlayerID is bound from route
        public int PlayerID { get; set; }

        public DeleteModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _defenseRepository = new DefenseRepository(connectionString);
                _gameRepository = new GameRepository(connectionString);
            }
        }

        public IActionResult OnGet(int playerId, int gameId)
        {
            PlayerID = playerId;  // Make sure this is set
            Defense = _defenseRepository.GetDefenseByPlayerAndGame(playerId, gameId);
            if (Defense == null)
            {
                return NotFound();
            }

            Game = _gameRepository.GetGameById(gameId);
            return Page();
        }

        public IActionResult OnPost(int playerId, int gameId)
        {
            PlayerID = playerId;  // Add this to ensure PlayerID is set in POST
            try
            {
                _defenseRepository.DeleteDefense(playerId, gameId);
                TempData["SuccessMessage"] = "Defense stats deleted successfully!";
                return RedirectToPage("/Individuals/Individual", new
                {
                    playerId = playerId,  // Use the parameter directly
                    activeTab = "defense"
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting defense stats: {ex.Message}";
                return RedirectToPage("/Individuals/Individual", new
                {
                    playerId = playerId,  // Use the parameter directly
                    activeTab = "defense"
                });
            }
        }
    }
}

