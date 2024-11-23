using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using DataAccess.Models;
using DataAccess.Repositories;

namespace Web_App.Pages.Teams
{
    public class TeamsModel : PageModel
    {
        private readonly ILogger<TeamsModel> _logger;
        private readonly TeamRepository _teamRepository;
        public List<Team> Teams { get; set; } = [];

        public TeamsModel(ILogger<TeamsModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null) _teamRepository = new TeamRepository(connectionString);
        }

        public void OnGet()
        {
            Teams = _teamRepository.GetAllTeams().ToList();
        }
    }
}