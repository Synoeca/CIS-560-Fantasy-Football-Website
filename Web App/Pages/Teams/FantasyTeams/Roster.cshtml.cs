using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using DataAccess.Repositories;

namespace Web_App.Pages.Teams.FantasyTeams
{
    public class RosterModel : PageModel
    {
        private readonly FantasyTeamPlayerRepository _fantasyTeamPlayerRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly PositionRepository _positionRepository;
        private readonly FantasyTeamRepository _fantasyTeamRepository;

        [BindProperty(SupportsGet = true)]
        public int FantasyTeamId { get; set; }

        public string FantasyTeamName { get; set; }

        public IEnumerable<FantasyTeamPlayer> Roster { get; set; } = new List<FantasyTeamPlayer>();

        public RosterModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            _fantasyTeamPlayerRepository = new FantasyTeamPlayerRepository(connectionString);
            _playerRepository = new PlayerRepository(connectionString);
            _positionRepository = new PositionRepository(connectionString);
            _fantasyTeamRepository = new FantasyTeamRepository(connectionString);
        }

        public void OnGet(int id)
        {
            FantasyTeamId = id;
            Roster = _fantasyTeamPlayerRepository.GetRosterByFantasyId(FantasyTeamId);
            FantasyTeamName = _fantasyTeamRepository.GetFantasyTeamNameById(FantasyTeamId);
        }

        public IActionResult OnPostRemovePlayerFromRoster(int playerId, int fantasyTeamId)
        {
            if (playerId <= 0 || fantasyTeamId <= 0)
            {
                return BadRequest();
            }

            _fantasyTeamPlayerRepository.RemovePlayerFromRoster(fantasyTeamId, playerId);
            return RedirectToPage(new { id = fantasyTeamId }); 
        }

        public string? GetPlayerName(int playerId)
        {
            return _playerRepository.GetPlayerNameById(playerId);
        }

        public string? GetPositionName(int positionId)
        {
            return _positionRepository.GetPositionNameById(positionId);
        }
    }
}