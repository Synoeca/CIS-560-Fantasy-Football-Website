using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class FantasyTeamPlayer
    {
        public int PlayerID { get; set; }
        public int? FantasyTeamID { get; set; }
        public int PositionID { get; set; }
    }
}
