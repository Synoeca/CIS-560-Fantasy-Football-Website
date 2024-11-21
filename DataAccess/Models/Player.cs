using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class Player
	{
		public int PlayerID { get; set; }
		public int TeamID { get; set; }
		public string Name { get; set; }
		public string Class { get; set; }
		public string HealthStatus { get; set; }
		public string BenchStatus { get; set; }
		public Player(int player, int team, string name, string classYear, string health, string bench)
		{
			this.PlayerID = player;
			this.TeamID = team;
			this.Name = name;
			this.Class = classYear;
			this.HealthStatus = health;
			this.BenchStatus = bench;
		}
	}
}
