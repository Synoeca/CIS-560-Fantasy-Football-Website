using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Teams.FantasyTeams
{
    public class DeleteModel : PageModel
    {
        private readonly FantasyTeamRepository _fantasyTeamRepository;

        [BindProperty]
        public FantasyTeam? Team { get; set; }

        public DeleteModel(IConfiguration configuration)
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
            if (Team == null)
            {
                return NotFound();
            }

            _fantasyTeamRepository.DeleteFantasyTeam(Team.FantasyTeamID);
            return RedirectToPage("./FantasyTeam");
        }
    }
}
