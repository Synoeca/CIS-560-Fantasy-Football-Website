using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_App.Pages.Players
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
            Teams = TeamRepository.GetAllTeams().ToList();

            TeamsList = Teams.Select(t => new SelectListItem
            {
                Value = t.TeamID.ToString(),
                Text = t.SchoolName
            }).ToList();

            ClassesList =
            [
                new SelectListItem { Value = "Freshman", Text = "Freshman" },
                new SelectListItem { Value = "Sophomore", Text = "Sophomore" },
                new SelectListItem { Value = "Junior", Text = "Junior" },
                new SelectListItem { Value = "Senior", Text = "Senior" }
            ];

            StatusList =
            [
                new SelectListItem { Value = "Active", Text = "Active" },
                new SelectListItem { Value = "Benched", Text = "Benched" }
            ];

            TotalFilteredCount = _playerRepository.GetFilteredPlayersCount(
                SearchString,
                TeamFilter,
                ClassFilter,
                StatusFilter
            );

            TotalPages = (int)Math.Ceiling(TotalFilteredCount / (double)PageSize);
            CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages));

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