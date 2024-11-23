using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class SpecialTeams
    {
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public int FieldGoalsMade { get; set; }
        public int FieldGoalsAttempted { get; set; }
        public int? ExtraPointsMade { get; set; } 
        public int? ExtraPointsAttempted { get; set; }
        public float ReturnYards { get; set; }
        public int ReturnAttempts { get; set; }
    }
}
