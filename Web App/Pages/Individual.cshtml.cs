using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages
{
    public class IndividualModel : PageModel
    {
        private readonly PlayerRepository _playerRepository;
        private readonly OffenseRepository _offenseRepository;
        private readonly DefenseRepository _defenseRepository;
        private readonly SpecialTeamsRepository _specialTeamsRepository;

        public Player? Player { get; set; }
        public List<Offense> OffenseStats { get; set; }
        public List<Defense> DefenseStats { get; set; }
        public List<SpecialTeams> SpecialTeamsStats { get; set; }
        public GameRepository GameRepository { get; set; }
        public TeamRepository TeamRepository { get; set; }

        public IndividualModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _playerRepository = new PlayerRepository(connectionString);
                _offenseRepository = new OffenseRepository(connectionString);
                _defenseRepository = new DefenseRepository(connectionString);
                _specialTeamsRepository = new SpecialTeamsRepository(connectionString);
                GameRepository = new GameRepository(connectionString);
                TeamRepository = new TeamRepository(connectionString);
            }
        }

        public IActionResult OnGet(int playerId)
        {
            Player = _playerRepository.GetPlayerById(playerId);
            OffenseStats = _offenseRepository.GetOffenseStatsByPlayerId(playerId);
            DefenseStats = _defenseRepository.GetDefenseStatsByPlayerId(playerId);
            SpecialTeamsStats = _specialTeamsRepository.GetSpecialTeamsStatsByPlayerId(playerId);

            return Page();
        }
    }
}