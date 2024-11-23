using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public int? HomeTeam { get; set; }
        public int? AwayTeam { get; set; }
        public DateTime Date { get; set; }
        public int Week { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}
