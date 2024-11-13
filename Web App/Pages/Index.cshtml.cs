// IndexModel.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using DataAccess.Models;
using System.Collections.Generic;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;

namespace Web_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PlayerRepository _playerRepository;
        public List<Player> Players { get; set; } = [];

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null) _playerRepository = new PlayerRepository(connectionString);
        }

        public void OnGet()
        {
            Players = _playerRepository.GetAllPlayers().ToList();
        }
    }
}