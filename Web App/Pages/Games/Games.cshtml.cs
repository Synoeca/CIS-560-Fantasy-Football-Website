using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using DataAccess.Models;
using System.Collections.Generic;
using DataAccess.Repositories;

namespace Web_App.Pages.Games
{
    public class GamesModel : PageModel
    {
        private readonly ILogger<GamesModel> _logger;
        public GameRepository GameRepository { get; set; }
        public List<Game> Games { get; set; } = [];

        public GamesModel(ILogger<GamesModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                GameRepository = new GameRepository(connectionString);
            }
        }

        public void OnGet()
        {
            Games = GameRepository.GetAllGames().ToList();
        }
    }
}