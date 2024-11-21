using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace Web_App.Pages.Individuals.Offenses
{
    public class CreateModel : PageModel
    {
        private readonly OffenseRepository _offenseRepository;
        private readonly GameRepository _gameRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly TeamRepository _teamRepository;

        [BindProperty]
        public Offense Offense { get; set; } 
        [BindProperty]
        public int PlayerID { get; set; }
        public List<SelectListItem> GamesList { get; set; } = [];

        public CreateModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _offenseRepository = new OffenseRepository(connectionString);
                _gameRepository = new GameRepository(connectionString);
                _playerRepository = new PlayerRepository(connectionString);
                _teamRepository = new TeamRepository(connectionString);
            }
        }

        public void OnGet(int playerId)
        {
            PlayerID = playerId;
            IEnumerable<Game> allGames = _gameRepository.GetAllGames();

            List<Offense>? playerOffenseStats = _offenseRepository.GetOffenseStatsByPlayerId(playerId);
            HashSet<int> existingGameIds = [..playerOffenseStats!.Select(o => o.GameID)];
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
                return Page();
            }

            try
            {
                Offense.PlayerID = PlayerID;
                _offenseRepository.InsertOffense(Offense);
                TempData["SuccessMessage"] = "Offense stats added successfully!";
                return RedirectToPage("/Individuals/Individual", new
                {
                    playerId = PlayerID,
                    activeTab = "offense"
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating offense stats: {ex.Message}");
                OnGet(PlayerID);
                return Page();
            }
        }
    }
}

