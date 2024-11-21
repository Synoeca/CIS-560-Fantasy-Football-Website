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
        public Offense(int player, int game, int passYards, int passAtt, int rushYards, int carries, int recieveYards, int receptions, int tds)
        {
            this.PlayerID = player;
            this.GameID = game;
            this.PassingYards = passYards;
            this.PassingAttempts = passAtt;
            this.RushingYards = rushYards;
            this.Carries = carries;
            this.ReceivingYards = recieveYards;
            this.Receptions = receptions;
            this.Touchdowns = tds;
        }
    }
}
