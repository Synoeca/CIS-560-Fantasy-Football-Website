using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Offense
    {
        public int PlayerID { get; set; }
        public int GameID { get; set; }
        public float PassingYards { get; set; }
        public int PassingAttempts { get; set; }
        public float RushingYards { get; set; }
        public int Carries { get; set; }
        public float ReceivingYards { get; set; }
        public int Receptions { get; set; }
        public int Touchdowns { get; set; }
    }
}
