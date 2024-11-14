using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using DataAccess.Models;
using System.Collections.Generic;
using DataAccess.Repositories;

namespace Web_App.Pages
{
    public class SeasonsModel : PageModel
    {
        private readonly ILogger<SeasonsModel> _logger;
        public SeasonsRepository SeasonsRepository { get; set; }
        public TeamRepository TeamRepository { get; private set; }
        public List<Seasons> Seasons { get; set; } = [];

        public SeasonsModel(ILogger<SeasonsModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString != null)
            {
                SeasonsRepository = new SeasonsRepository(connectionString);
                TeamRepository = new TeamRepository(connectionString);
            }
        }

        public void OnGet()
        {
            Seasons = SeasonsRepository.GetAllSeasons().ToList();
        }
    }
}