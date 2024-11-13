// IndexModel.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using DataAccess.Repositories;

namespace Web_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PlayerRepository _playerRepository;
        private readonly TeamRepository _teamRepository;
        private readonly GameRepository _gameRepository;

        public List<Player> Players { get; set; } = [];
        public List<Team> Teams { get; set; } = [];
        public List<Game> Games { get; set; } = [];

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _playerRepository = new PlayerRepository(connectionString);
                _teamRepository = new TeamRepository(connectionString);
                _gameRepository = new GameRepository(connectionString);
            }
        }

        public void OnGet()
        {
            try
            {
                Players = _playerRepository.GetAllPlayers().ToList();
                Teams = _teamRepository.GetAllTeams().ToList();
                Games = _gameRepository.GetAllGames()
                    .OrderByDescending(g => g.Date)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading dashboard data");
            }
        }
    }
}