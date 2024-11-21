using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Players
{
    public class DeleteModel : PageModel
    {
        private readonly PlayerRepository _playerRepository;
        private readonly TeamRepository _teamRepository;

        [BindProperty]
        public Player? Player { get; set; } 
        public string TeamName { get; set; } = string.Empty;

        public DeleteModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _playerRepository = new PlayerRepository(connectionString);
                _teamRepository = new TeamRepository(connectionString);
            }
            else
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
        }

        public IActionResult OnGet(int id)
        {
            Player = _playerRepository.GetPlayerById(id) ?? null;
            if (Player == null)
            {
                return NotFound();
            }

            TeamName = _teamRepository.GetTeamNameById(Player.TeamID);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Player.PlayerID == 0)
            {
                return NotFound();
            }

            try
            {
                _playerRepository.DeletePlayer(Player.PlayerID);
                TempData["SuccessMessage"] = "Player deleted successfully!";
                return RedirectToPage("./Player");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting player: {ex.Message}";
                return RedirectToPage("./Player");
            }
        }
    }
}