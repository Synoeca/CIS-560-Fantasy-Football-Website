using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace Web_App.Pages
{
    public class FantasyTeamModel : PageModel
    {
        private readonly FantasyTeamRepository _fantasyTeamRepository;

        public FantasyTeamModel(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                _fantasyTeamRepository = new FantasyTeamRepository(connectionString);
            }
        }

        public IEnumerable<FantasyTeam> FantasyTeams { get; set; } = new List<FantasyTeam>();

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
        }
    }
}