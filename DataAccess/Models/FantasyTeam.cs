using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class FantasyTeam
	{
        public int FantasyTeamID { get; set; }
        public string FantasyTeamName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string DraftStatus { get; set; } = "Not Started";

        public FantasyTeam (int id, string name, int win, int loss)
        {
            this.FantasyTeamID = id;
            this.FantasyTeamName = name;
            this.Wins = win;
            this.Losses = loss;
        }
        public FantasyTeam ()
        {

        }
    }
}

