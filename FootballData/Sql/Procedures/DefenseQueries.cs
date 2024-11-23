using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballData.Sql.Queries
{
    public static class DefenseQueries
    {
        public static readonly string GetAllDefenses = "SELECT * FROM Football.Defense";

        public static readonly string GetDefenseStatsByPlayerId = "SELECT * FROM Football.Defense WHERE PlayerID = @PlayerID";

        public static readonly string GetDefenseByPlayerAndGame = "SELECT * FROM Football.Defense WHERE PlayerID = @PlayerID AND GameID = @GameID";

        public static readonly string InsertDefense = """
              INSERT INTO Football.Defense (PlayerID, GameID, Interceptions, Tackles, Sacks, ForcedFumbles)
              VALUES (@PlayerID, @GameID, @Interceptions, @Tackles, @Sacks, @ForcedFumbles)
          """;

        public static readonly string UpdateDefense = """
              UPDATE Football.Defense 
              SET Interceptions = @Interceptions, 
                  Tackles = @Tackles, 
                  Sacks = @Sacks, 
                  ForcedFumbles = @ForcedFumbles
              WHERE PlayerID = @PlayerID AND GameID = @GameID
          """;

        public static readonly string DeleteDefense = "DELETE FROM Football.Defense WHERE PlayerID = @PlayerID AND GameID = @GameID";
    }
}
