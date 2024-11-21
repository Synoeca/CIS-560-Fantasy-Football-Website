using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class SeasonsQueries
    {
        public static readonly string GetAllSeasons = """
              SELECT SeasonID, GameID, TeamID, Year, Wins, Loses 
              FROM Football.Seasons 
              ORDER BY Year DESC
         """;

        public static readonly string GetSeasonById = """
              SELECT SeasonID, GameID, TeamID, Year, Wins, Loses 
              FROM Football.Seasons 
              WHERE SeasonID = @SeasonID
         """;

        public static readonly string GetSeasonsByYear = """
             SELECT SeasonID, GameID, TeamID, Year, Wins, Loses 
             FROM Football.Seasons 
             WHERE Year = @Year
         """;

        public static readonly string InsertSeason = """
             INSERT INTO Football.Seasons (SeasonID, GameID, TeamID, Year, Wins, Loses)
             VALUES (@SeasonID, @GameID, @TeamID, @Year, @Wins, @Loses)
         """;

        public static readonly string UpdateSeason = """
             UPDATE Football.Seasons 
             SET GameID = @GameID,
                 TeamID = @TeamID,
                 Year = @Year,
                 Wins = @Wins,
                 Loses = @Loses
             WHERE SeasonID = @SeasonID
         """;

        public static readonly string DeleteSeason = """
             DELETE FROM Football.Seasons 
             WHERE SeasonID = @SeasonID
         """;
    }
}