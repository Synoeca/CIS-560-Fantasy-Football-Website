using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Web_App.Pages.Individuals.Defenses
{
    public class EditModel : PageModel
    {
        private readonly DefenseRepository _defenseRepository;
        private readonly GameRepository _gameRepository;

        [BindProperty]
        public Defense? Defense { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int PlayerID { get; set; }

        public Game? Game { get; set; }

        public EditModel(IConfiguration configuration)
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
            PlayerID = playerId;
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
            PlayerID = playerId;
            if (!ModelState.IsValid)
            {
                Game = _gameRepository.GetGameById(gameId);
                return Page();
            }

            try
            {
                _defenseRepository.UpdateDefense(Defense);
                TempData["SuccessMessage"] = "Defense stats updated successfully!";
                return RedirectToPage("/Individuals/Individual", new
                {
                    playerId = playerId,
                    activeTab = "defense"
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating defense stats: {ex.Message}");
                Game = _gameRepository.GetGameById(gameId);
                return Page();
            }
        }
    }
}

