using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_App.Pages
{
    public class PlayerModel : PageModel
    {
        private readonly ILogger<PlayerModel> _logger;
        private readonly PlayerRepository _playerRepository;
        public int TotalFilteredCount { get; set; }
        public TeamRepository TeamRepository { get; set; }
        public List<Player> Players { get; set; } = [];
        public List<Team> Teams { get; set; } = [];

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TeamFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ClassFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? StatusFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 20;
        public int TotalPages { get; set; }
        public List<SelectListItem> TeamsList { get; set; } = [];
        public List<SelectListItem> ClassesList { get; set; } = [];
        public List<SelectListItem> StatusList { get; set; } = [];

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
            // Get Teams for dropdown
            Teams = TeamRepository.GetAllTeams().ToList();

            // Populate filter dropdowns
            TeamsList = Teams.Select(t => new SelectListItem
            {
                Value = t.TeamID.ToString(),
                Text = t.SchoolName
            }).ToList();

            ClassesList =
            [
                new() { Value = "Freshman", Text = "Freshman" },
                new() { Value = "Sophomore", Text = "Sophomore" },
                new() { Value = "Junior", Text = "Junior" },
                new() { Value = "Senior", Text = "Senior" }
            ];

            StatusList =
            [
                new() { Value = "Active", Text = "Active" },
                new() { Value = "Benched", Text = "Benched" }
            ];

            // Get total count
            TotalFilteredCount = _playerRepository.GetFilteredPlayersCount(
                SearchString,
                TeamFilter,
                ClassFilter,
                StatusFilter
            );

            // Calculate pagination
            TotalPages = (int)Math.Ceiling(TotalFilteredCount / (double)PageSize);
            CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages));

            // Get filtered and paginated data
            Players = _playerRepository.GetFilteredPlayers(
                SearchString,
                TeamFilter,
                ClassFilter,
                StatusFilter,
                SortOrder,
                CurrentPage,
                PageSize
            ).ToList();
        }
    }
}