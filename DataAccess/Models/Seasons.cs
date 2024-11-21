using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Seasons
    {
        public int SeasonID { get; set; }
        public int? GameID { get; set; }
        public int? TeamID { get; set; }
        public int? Year { get; set; }
        public int? Wins { get; set; }
        public int? Loses { get; set; }
        public Seasons (int season, int? game, int? team, int? year, int? win, int? loss)
        {
            this.SeasonID = season;
            this.GameID = game;
            this.TeamID = team;
            this.Year = year;
            this.Wins = win;
            this.Loses = loss;
        }
    }
}