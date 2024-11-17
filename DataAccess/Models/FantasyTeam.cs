using System;
using System.Collections.Generic;
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
	}
}

