using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages
{
    public class FantasyTeamPerformanceModel : PageModel
    {
        private readonly ILogger<FantasyTeamPerformanceModel> _logger;
        private readonly FantasyTeamRepository _repository = null!;

        public Dictionary<FantasyTeam, (
            decimal PassYds,
            int PassAtt,
            decimal RushYds,
            int Carries,
            decimal RecYds,
            int Receptions,
            int TDs,
            int Tackles,
            int Sacks,
            int Ints,
            int ForcedFumbles,
            int FGs,
            int XPs,
            decimal ReturnYds,
            int ReturnAtt)> Performance2024
        { get; set; } = [];

        public Dictionary<FantasyTeam, (
            decimal PassYds,
            int PassAtt,
            decimal RushYds,
            int Carries,
            decimal RecYds,
            int Receptions,
            int TDs,
            int Tackles,
            int Sacks,
            int Ints,
            int ForcedFumbles,
            int FGs,
            int XPs,
            decimal ReturnYds,
            int ReturnAtt)> Performance2023
        { get; set; } = [];

        public FantasyTeamPerformanceModel(ILogger<FantasyTeamPerformanceModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _repository = new FantasyTeamRepository(connectionString);
            }
        }

        public void OnGet()
        {
            Performance2024 = _repository.GetTeamAveragePerformance(2024);
            Performance2023 = _repository.GetTeamAveragePerformance(2023);
        }
    }
}