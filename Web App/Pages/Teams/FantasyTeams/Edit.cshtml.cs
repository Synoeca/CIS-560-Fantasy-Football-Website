using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Teams.FantasyTeams
{
    public class EditModel : PageModel
    {
        private readonly FantasyTeamRepository _fantasyTeamRepository;

        [BindProperty]
        public FantasyTeam? Team { get; set; }

        public EditModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _fantasyTeamRepository = new FantasyTeamRepository(connectionString);
            }
        }

        public IActionResult OnGet(int id)
        {
            Team = _fantasyTeamRepository.GetFantasyTeamById(id);
            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Team == null)
            {
                return Page();
            }

            _fantasyTeamRepository.UpdateFantasyTeam(Team);
            return RedirectToPage("./FantasyTeam");
        }
    }
}
