using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class SeasonsQueries
    {
        /// <summary>
        /// Gets all seasons ordered by year
        /// </summary>
        public static readonly string GetAllSeasons = """
                                                      SELECT SeasonID, GameID, TeamID, Year, Wins, Loses 
                                                      FROM Football.Seasons 
                                                      ORDER BY Year DESC
                                                      """;

        /// <summary>
        /// Gets a season by its ID
        /// </summary>
        public static readonly string GetSeasonById = """
                                                      SELECT SeasonID, GameID, TeamID, Year, Wins, Loses 
                                                      FROM Football.Seasons 
                                                      WHERE SeasonID = @SeasonID
                                                      """;

        /// <summary>
        /// Gets all seasons for a specific year
        /// </summary>
        public static readonly string GetSeasonsByYear = """
                                                         SELECT SeasonID, GameID, TeamID, Year, Wins, Loses 
                                                         FROM Football.Seasons 
                                                         WHERE Year = @Year
                                                         """;

        /// <summary>
        /// Inserts a new season record
        /// </summary>
        public static readonly string InsertSeason = """
                                                     INSERT INTO Football.Seasons (SeasonID, GameID, TeamID, Year, Wins, Loses)
                                                     VALUES (@SeasonID, @GameID, @TeamID, @Year, @Wins, @Loses)
                                                     """;

        /// <summary>
        /// Updates an existing season record
        /// </summary>
        public static readonly string UpdateSeason = """
                                                     UPDATE Football.Seasons 
                                                     SET GameID = @GameID,
                                                         TeamID = @TeamID,
                                                         Year = @Year,
                                                         Wins = @Wins,
                                                         Loses = @Loses
                                                     WHERE SeasonID = @SeasonID
                                                     """;

        /// <summary>
        /// Deletes a season record
        /// </summary>
        public static readonly string DeleteSeason = """
                                                     DELETE FROM Football.Seasons 
                                                     WHERE SeasonID = @SeasonID
                                                     """;
    }
}