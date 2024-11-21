using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Web_App.Pages.Individuals.Offenses
{
    public class DeleteModel : PageModel
    {
        private readonly OffenseRepository _offenseRepository;
        private readonly GameRepository _gameRepository;

        [BindProperty]
        public Offense Offense { get; set; }
        public Game? Game { get; set; }

        [BindProperty(SupportsGet = true)]  // Add this to ensure PlayerID is bound from route
        public int PlayerID { get; set; }

        public DeleteModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _offenseRepository = new OffenseRepository(connectionString);
                _gameRepository = new GameRepository(connectionString);
            }
        }

        public IActionResult OnGet(int playerId, int gameId)
        {
            PlayerID = playerId;  // Make sure this is set
            Offense = _offenseRepository.GetOffenseByPlayerAndGame(playerId, gameId);
            if (Offense == null)
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
                _offenseRepository.DeleteOffense(playerId, gameId);
                TempData["SuccessMessage"] = "Offense stats deleted successfully!";
                return RedirectToPage("/Individuals/Individual", new
                {
                    playerId = playerId,  // Use the parameter directly
                    activeTab = "offense"
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting defense stats: {ex.Message}";
                return RedirectToPage("/Individuals/Individual", new
                {
                    playerId = playerId,  // Use the parameter directly
                    activeTab = "offense"
                });
            }
        }
    }
}
