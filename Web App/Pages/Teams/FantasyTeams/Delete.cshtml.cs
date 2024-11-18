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

        public bool IsDraftInProgress { get; set; }

        public DeleteModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            _fantasyTeamRepository = new FantasyTeamRepository(connectionString);
        }

        public IActionResult OnGet(int id)
        {
            Team = _fantasyTeamRepository.GetFantasyTeamById(id);
            if (Team == null)
            {
                return NotFound();
            }

            // Check if draft is in progress
            IsDraftInProgress = _fantasyTeamRepository.IsDraftInProgress();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Team == null)
            {
                return NotFound();
            }

            // Check if draft is in progress before allowing deletion
            IsDraftInProgress = _fantasyTeamRepository.IsDraftInProgress();
            if (IsDraftInProgress)
            {
                ModelState.AddModelError(string.Empty, "Cannot delete team while draft is in progress.");
                return Page(); // Return to the page with an error message
            }

            _fantasyTeamRepository.DeleteFantasyTeam(Team.FantasyTeamID);
            return RedirectToPage("./FantasyTeam");
        }
    }
}