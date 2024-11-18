using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using DataAccess.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web_App.Pages.Teams.FantasyTeams
{
    public class FantasyTeamModel : PageModel
    {
        private readonly FantasyTeamRepository _fantasyTeamRepository;
        private readonly FantasyTeamPlayerRepository _fantasyTeamPlayerRepository;

        public PlayerRepository? PlayerRepository { get; set; }
        public TeamRepository? TeamRepository { get; set; }
        public PositionRepository? PositionRepository { get; set; }

        public List<SelectListItem> PositionsList { get; set; } = [];

        [BindProperty(SupportsGet = true)]
        public string PlayerSearchString { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public string PlayerSortOrder { get; set; } = "";
        [BindProperty(SupportsGet = true)]
        public int PlayerCurrentPage { get; set; } = 1;
        public int PlayerPageSize { get; set; } = 10;
        public int PlayerTotalPages { get; set; }
        public int PlayerTotalCount { get; set; }
        [BindProperty(SupportsGet = true)]
        public string PositionFilter { get; set; } = "";
        [BindProperty]
        public int SelectedFantasyTeamId { get; set; }
        public int CurrentDraftingTeamId { get; set; }


        public FantasyTeamModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _fantasyTeamRepository = new FantasyTeamRepository(connectionString);
                _fantasyTeamPlayerRepository = new FantasyTeamPlayerRepository(connectionString);
                PlayerRepository = new PlayerRepository(connectionString);
                TeamRepository = new TeamRepository(connectionString);
                PositionRepository = new PositionRepository(connectionString);
            }
        }

        public IEnumerable<FantasyTeam> FantasyTeams { get; set; } = new List<FantasyTeam>();
        public IEnumerable<FantasyTeamPlayer> AvailablePlayers { get; set; } = new List<FantasyTeamPlayer>(); // Changed to FantasyTeamPlayer

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public int TotalFilteredCount { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TeamFilter { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string ClassFilter { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string StatusFilter { get; set; } = "";

        public bool IsDraftInProgress { get; set; }
        public int CurrentDraftRound { get; set; }
        public int CurrentDraftPosition { get; set; }

        public void OnGet()
        {
            TotalFilteredCount = _fantasyTeamRepository.GetFilteredFantasyTeamsCount(SearchString);
            TotalPages = (int)Math.Ceiling(TotalFilteredCount / (double)PageSize);

            FantasyTeams = _fantasyTeamRepository.GetFilteredFantasyTeams(
                SearchString,
                SortOrder,
                CurrentPage,
                PageSize
            );

            IEnumerable<Position>? positions = PositionRepository?.GetAllPositions();
            if (positions != null)
                PositionsList = positions.Select(p => new SelectListItem
                {
                    Value = p.PositionID.ToString(),
                    Text = p.PositionName
                }).ToList();

            PositionsList.Insert(0, new SelectListItem { Value = "", Text = "All Positions" });

            // Get draft status
            IsDraftInProgress = _fantasyTeamRepository.IsDraftInProgress();
            if (IsDraftInProgress)
            {
                CurrentDraftRound = _fantasyTeamRepository.GetCurrentDraftRound();
                CurrentDraftPosition = _fantasyTeamRepository.GetCurrentDraftPosition();

                // Get the currently drafting team
                CurrentDraftingTeamId = _fantasyTeamRepository.GetCurrentDraftingTeamId();

                // Get filtered and paginated available players
                (IEnumerable<FantasyTeamPlayer>? players, int totalCount) = _fantasyTeamPlayerRepository.GetFilteredAvailablePlayers(
                    PlayerSearchString,
                    PlayerSortOrder,
                    PositionFilter,
                    PlayerCurrentPage,
                    PlayerPageSize
                );

                AvailablePlayers = players;
                PlayerTotalCount = totalCount;
                PlayerTotalPages = (int)Math.Ceiling(totalCount / (double)PlayerPageSize);
            }
        }

        public IActionResult OnPostStartDraft()
        {
            _fantasyTeamRepository.StartDraft();
            return RedirectToPage();
        }

        public IActionResult OnPostDraftPlayer(int playerId, int fantasyTeamId)
        {
            // Assuming that PositionID is already part of the FantasyTeamPlayer model
            _fantasyTeamPlayerRepository.AddPlayerToTeam(fantasyTeamId, playerId, _fantasyTeamRepository);
            _fantasyTeamRepository.MoveToDraftPosition();
            return RedirectToPage();
        }

        public IActionResult OnPostEndDraft()
        {
            _fantasyTeamRepository.EndDraft();
            return RedirectToPage();
        }
    }
}