using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages
{
    public class SeasonPerformanceModel : PageModel
    {
        private readonly ILogger<SeasonPerformanceModel> _logger;
        private readonly SeasonsRepository _seasonsRepository = null!;

        public List<SeasonPerformance> Performance2024 { get; set; } = [];
        public List<SeasonPerformance> Performance2023 { get; set; } = [];

        public SeasonPerformanceModel(ILogger<SeasonPerformanceModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _seasonsRepository = new SeasonsRepository(connectionString);
            }
        }

        public void OnGet()
        {
            Performance2024 = (List<SeasonPerformance>)_seasonsRepository.GetSeasonPerformance(2024);
            Performance2023 = (List<SeasonPerformance>)_seasonsRepository.GetSeasonPerformance(2023);
        }
    }
}
