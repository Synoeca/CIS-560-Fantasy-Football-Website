using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages
{
    public class PlayerPerformanceModel : PageModel
    {
        private readonly PlayerRepository _playerRepository;
        public PlayerRepository PlayerRepository { get; set; }

        public List<PlayerGamePerformance> Performance2024 { get; set; } = [];
        public List<PlayerGamePerformance> Performance2023 { get; set; } = [];

        public PlayerPerformanceModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _playerRepository = new PlayerRepository(connectionString);
                PlayerRepository = new PlayerRepository(connectionString);
            }
        }

        public void OnGet()
        {
            Performance2024 = _playerRepository.GetPlayerPerformance(2024).ToList();
            Performance2023 = _playerRepository.GetPlayerPerformance(2023).ToList();
        }
    }
}
