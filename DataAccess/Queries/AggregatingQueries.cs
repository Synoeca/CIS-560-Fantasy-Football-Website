using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Queries
{
    public static class AggregatingQueries
    {
        public static readonly string GetTeamPerformanceBySeason = """
                       SELECT 
                           s.Year AS Season,
                           t.SchoolName, 
                           SUM(s.Wins) AS Wins, 
                           SUM(s.Loses) AS Losses,
                           ROUND((SUM(s.Wins) * 100.0 / (SUM(s.Wins) + SUM(s.Loses))), 2) AS WinningPercentage
                       FROM Football.Seasons s
                           INNER JOIN Football.Team t ON s.TeamID = t.TeamID
                       WHERE s.Year = @Year
                       GROUP BY t.SchoolName, s.Year
                       ORDER BY s.Year DESC
           """;

        public static readonly string GetPlayerPerformanceByGame = """
                     SELECT 
                         p.PlayerID,
                         AVG(o.PassingAttempts) AS AveragePassingAttempts,
                         AVG(o.RushingYards) AS AverageRushingYards,
                         AVG(o.Carries) AS AverageCarries,
                         AVG(o.ReceivingYards) AS AverageReceivingYards,
                         AVG(o.Receptions) AS AverageReceptions,
                         AVG(o.Touchdowns) AS AverageTouchdowns
                     FROM Football.Player p
                     INNER JOIN Football.Offense o ON p.PlayerID = o.PlayerID
                     INNER JOIN Football.Game g ON o.GameID = g.GameID
                     WHERE YEAR(g.[Date]) = @Year
                     GROUP BY p.PlayerID;
          """;
    }
}
