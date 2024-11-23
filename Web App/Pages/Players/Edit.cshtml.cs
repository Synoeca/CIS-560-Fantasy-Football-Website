using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_App.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly PlayerRepository _playerRepository;
        private readonly TeamRepository _teamRepository;

        [BindProperty]
        public Player Player { get; set; } = new();
        public List<SelectListItem> TeamsList { get; set; } = [];
        public List<SelectListItem> ClassesList { get; set; } =
        [
            new() { Value = "Freshman", Text = "Freshman" },
            new() { Value = "Sophomore", Text = "Sophomore" },
            new() { Value = "Junior", Text = "Junior" },
            new() { Value = "Senior", Text = "Senior" }
        ];

        public EditModel(IConfiguration configuration)
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
            Player = _playerRepository.GetPlayerById(id) ?? new Player();
            if (Player.PlayerID == 0)
            {
                return NotFound();
            }

            IEnumerable<Team> teams = _teamRepository.GetAllTeams();
            TeamsList = teams.Select(t => new SelectListItem
            {
                Value = t.TeamID.ToString(),
                Text = t.SchoolName
            }).ToList();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _playerRepository.UpdatePlayer(Player);
                TempData["SuccessMessage"] = "Player updated successfully!";
                return RedirectToPage("./Player");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating player: {ex.Message}");
                IEnumerable<Team> teams = _teamRepository.GetAllTeams();
                TeamsList = teams.Select(t => new SelectListItem
                {
                    Value = t.TeamID.ToString(),
                    Text = t.SchoolName
                }).ToList();
                return Page();
            }
        }
    }
}