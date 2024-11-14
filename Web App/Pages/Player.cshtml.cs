using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages
{
    public class PlayerModel : PageModel
    {
        private readonly ILogger<PlayerModel> _logger;
        private readonly PlayerRepository _playerRepository;
        public TeamRepository TeamRepository { get; set; }
        public List<Player> Players { get; set; } = [];
        public List<Team> Teams { get; set; } = [];

        public PlayerModel(ILogger<PlayerModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _playerRepository = new PlayerRepository(connectionString);
                TeamRepository = new TeamRepository(connectionString);
            }
               
        }

        public void OnGet()
        {
            Players = _playerRepository.GetAllPlayers().ToList();
            Teams = TeamRepository.GetAllTeams().ToList();
        }
    }
}
