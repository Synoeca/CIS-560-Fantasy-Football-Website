using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_App.Pages.Individuals.SpecialTeam
{
    public class CreateModel : PageModel
    {
        private readonly SpecialTeamsRepository _specialTeamsRepository;
        private readonly GameRepository _gameRepository;
        private readonly TeamRepository _teamRepository;

        [BindProperty]
        public SpecialTeams SpecialTeams { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int PlayerID { get; set; }

        public List<SelectListItem> GamesList { get; set; } = [];

        public CreateModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _specialTeamsRepository = new SpecialTeamsRepository(connectionString);
                _gameRepository = new GameRepository(connectionString);
                _teamRepository = new TeamRepository(connectionString);
            }
            else
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
        }

        public void OnGet(int playerId)
        {
            PlayerID = playerId;
            IEnumerable<Game> allGames = _gameRepository.GetAllGames();

            // Get the games this player already has special teams stats for
            List<SpecialTeams>? playerSpecialTeamsStats = _specialTeamsRepository.GetSpecialTeamsStatsByPlayerId(playerId);
            HashSet<int> existingGameIds = [..playerSpecialTeamsStats!.Select(s => s.GameID)];

            // Filter out the games the player already has stats for
            IEnumerable<Game> availableGames = allGames.Where(g => !existingGameIds.Contains(g.GameID));

            GamesList = availableGames.Select(g => new SelectListItem
            {
                Value = g.GameID.ToString(),
                Text = $"{g.Date:MM/dd/yyyy} - {_teamRepository.GetTeamNameById((int)g.HomeTeam!)} vs {_teamRepository.GetTeamNameById((int)g.AwayTeam!)}"
            }).ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                OnGet(PlayerID);
                return Page();
            }

            try
            {
                SpecialTeams.PlayerID = PlayerID;
                _specialTeamsRepository.InsertSpecialTeamsStats(SpecialTeams);
                TempData["SuccessMessage"] = "Special Teams stats created successfully!";
                return RedirectToPage("/Individuals/Individual", new { playerId = PlayerID, activeTab = "specialteams" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating Special Teams stats: {ex.Message}");
                OnGet(PlayerID);
                return Page();
            }
        }
    }
}