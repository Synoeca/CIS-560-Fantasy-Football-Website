// IndexModel.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Models;
using System.Collections.Generic;

namespace Web_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PlayerRepository _playerRepository;
        public List<Player> Players { get; set; } = new List<Player>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _playerRepository = new PlayerRepository(
                "Server=(localdb)\\MSSQLLocalDB;Database=CIS560;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public void OnGet()
        {
            Players = _playerRepository.GetAllPlayers().ToList();
        }
    }
}