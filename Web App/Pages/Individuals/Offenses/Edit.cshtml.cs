using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace Web_App.Pages.Individuals.Offenses
{
    public class EditModel : PageModel
    {
        private readonly OffenseRepository _offenseRepository;
        private readonly GameRepository _gameRepository;

        [BindProperty]
        public Offense Offense { get; set; } 

        [BindProperty(SupportsGet = true)]
        public int PlayerID { get; set; }

        public Game? Game { get; set; }

        public EditModel(IConfiguration configuration)
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
            PlayerID = playerId;
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
            PlayerID = playerId;
            if (!ModelState.IsValid)
            {
                Game = _gameRepository.GetGameById(gameId);
                return Page();
            }

            try
            {
                _offenseRepository.UpdateOffense(Offense);
                TempData["SuccessMessage"] = "Offense stats updated successfully!";
                return RedirectToPage("/Individuals/Individual", new
                {
                    playerId = playerId,
                    activeTab = "offense"
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating offense stats: {ex.Message}");
                Game = _gameRepository.GetGameById(gameId);
                return Page();
            }
        }
    }
}