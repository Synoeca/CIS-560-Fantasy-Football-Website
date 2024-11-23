using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages
{
    public class FantasyTeamPointsModel : PageModel
    {
        private readonly ILogger<FantasyTeamPointsModel> _logger;
        private readonly FantasyTeamRepository _fantasyTeamRepository = null!;

        public PositionRepository PositionRepository = null!;

        public Dictionary<FantasyTeam, List<(string PlayerName, int Position, int Points)>> DetailedPerformance2024
        {
            get;
            set;
        } = [];

        public Dictionary<FantasyTeam, List<(string PlayerName, int Position, int Points)>> DetailedPerformance2023
        {
            get;
            set;
        } = [];

        public Dictionary<FantasyTeam, int> TeamPoints2024 { get; set; } = [];
        public Dictionary<FantasyTeam, int> TeamPoints2023 { get; set; } = [];

        public FantasyTeamPointsModel(ILogger<FantasyTeamPointsModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _fantasyTeamRepository = new FantasyTeamRepository(connectionString);
                PositionRepository = new PositionRepository(connectionString);
            }
        }

        public void OnGet()
        {
            DetailedPerformance2024 = _fantasyTeamRepository.GetFantasyTeamPerformance(2024);
            DetailedPerformance2023 = _fantasyTeamRepository.GetFantasyTeamPerformance(2023);
            TeamPoints2024 = _fantasyTeamRepository.GetFantasyTeamPoints(2024);
            TeamPoints2023 = _fantasyTeamRepository.GetFantasyTeamPoints(2023);
        }
    }
}
