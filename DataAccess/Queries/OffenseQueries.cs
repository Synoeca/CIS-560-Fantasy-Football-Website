using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class OffenseQueries
    {
        public static readonly string GetAllOffenses = "SELECT * FROM Football.Offense";
        public static readonly string GetOffenseStatsByPlayerId = "SELECT * FROM Football.Offense WHERE PlayerID = @PlayerID";
        public static readonly string GetOffenseByPlayerAndGame = "SELECT * FROM Football.Offense WHERE PlayerID = @PlayerID AND GameID = @GameID";

        public static readonly string InsertOffense = """
              INSERT INTO Football.Offense (PlayerID, GameID, PassingYards, PassingAttempts, RushingYards, Carries, ReceivingYards, Receptions, Touchdowns)
              VALUES (@PlayerID, @GameID, @PassingYards, @PassingAttempts, @RushingYards, @Carries, @ReceivingYards, @Receptions, @Touchdowns)
          """;

        public static readonly string UpdateOffense = """
              UPDATE Football.Offense 
              SET PassingYards = @PassingYards,
                  PassingAttempts = @PassingAttempts,
                  RushingYards = @RushingYards,
                  Carries = @Carries,
                  ReceivingYards = @ReceivingYards,
                  Receptions = @Receptions,
                  Touchdowns = @Touchdowns
              WHERE PlayerID = @PlayerID AND GameID = @GameID
          """;

        public static readonly string DeleteOffense = "DELETE FROM Football.Offense WHERE PlayerID = @PlayerID AND GameID = @GameID";
    }
}
