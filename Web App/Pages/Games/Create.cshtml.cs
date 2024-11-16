using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_App.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly GameRepository _gameRepository;
        private readonly TeamRepository _teamRepository;

        [BindProperty]
        public Game Game { get; set; } = new()
        {
            Date = DateTime.Today
        };
        public List<SelectListItem> TeamsList { get; set; } = [];

        public CreateModel(IConfiguration configuration)
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

        public void OnGet()
        {
            IEnumerable<Team> teams = _teamRepository.GetAllTeams();
            TeamsList = teams.Select(t => new SelectListItem
            {
                Value = t.TeamID.ToString(),
                Text = t.SchoolName
            }).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _gameRepository.InsertGame(Game);
                TempData["SuccessMessage"] = "Game created successfully!";
                return RedirectToPage("./Games");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating game: {ex.Message}");
                OnGet(); // Reload the form data
                return Page();
            }
        }
    }
}