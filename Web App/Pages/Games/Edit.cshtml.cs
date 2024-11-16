using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_App.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly GameRepository _gameRepository;
        private readonly TeamRepository _teamRepository;

        [BindProperty]
        public Game Game { get; set; } = new();
        public List<SelectListItem> TeamsList { get; set; } = [];

        public EditModel(IConfiguration configuration)
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

            LoadTeamsList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadTeamsList();
                return Page();
            }

            try
            {
                _gameRepository.UpdateGame(Game);
                TempData["SuccessMessage"] = "Game updated successfully!";
                return RedirectToPage("./Games");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating game: {ex.Message}");
                LoadTeamsList();
                return Page();
            }
        }

        private void LoadTeamsList()
        {
            IEnumerable<Team> teams = _teamRepository.GetAllTeams();
            TeamsList = teams.Select(t => new SelectListItem
            {
                Value = t.TeamID.ToString(),
                Text = t.SchoolName
            }).ToList();
        }
    }
}