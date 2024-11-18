using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using DataAccess.Repositories;

namespace Web_App.Pages.Teams.FantasyTeams
{
    public class CreateModel : PageModel
    {
        private readonly FantasyTeamRepository _fantasyTeamRepository;

        [BindProperty]
        public FantasyTeam Team { get; set; } = new();

        public CreateModel(FantasyTeamRepository fantasyTeamRepository)
        {
            _fantasyTeamRepository = fantasyTeamRepository;
        }

        public IActionResult OnGet()
        {
            // Set default values for the new team
            Team.Wins = 0;
            Team.Losses = 0;
            Team.DraftStatus = "Not Started"; // Ensure default status is set

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Set default values
            Team.Wins = 0;
            Team.Losses = 0;
            Team.DraftStatus ??= "Not Started";

            _fantasyTeamRepository.CreateFantasyTeam(Team);
            return RedirectToPage("./FantasyTeam");
        }
    }
}