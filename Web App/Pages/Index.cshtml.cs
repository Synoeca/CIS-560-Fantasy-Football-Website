using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public GameRepository GameRepository { get; set; }
    public TeamRepository TeamRepository { get; set; }
    public PlayerRepository PlayerRepository { get; set; }

    public List<Game> Games { get; set; } = [];
    public List<Team> Teams { get; set; } = [];
    public List<Player> Players { get; set; } = [];

    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
    {
        _logger = logger;
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        if (connectionString != null)
        {
            GameRepository = new GameRepository(connectionString);
            TeamRepository = new TeamRepository(connectionString);
            PlayerRepository = new PlayerRepository(connectionString);
        }
    }

    public void OnGet()
    {
        Games = GameRepository.GetAllGames().ToList();
        Teams = TeamRepository.GetAllTeams().ToList();
        Players = PlayerRepository.GetAllPlayers().ToList();
    }
}