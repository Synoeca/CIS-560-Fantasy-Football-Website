﻿using System;
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
        public float ReturnYards { get; set; }
        public int ReturnAttempts { get; set; }
        public SpecialTeams (int player, int game, int fgMade, int fgAtt, float returnYards, int returnAtt)
        {
            this.PlayerID = player;
            this.GameID = game;
            this.FieldGoalsMade = fgMade;
            this.FieldGoalsAttempted = fgAtt;
            this.ReturnYards = returnYards;
            this.ReturnAttempts = returnAtt;
        }
        public SpecialTeams ()
        {

        }
    }
}
