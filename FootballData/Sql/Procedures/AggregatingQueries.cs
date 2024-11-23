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

        public static readonly string GetFantasyTeamPointsBySeason = """
             SELECT 
                 ft.FantasyTeamID,
                 ft.FantasyTeamName,
                 SUM(ISNULL(o.Touchdowns * 6, 0) + ISNULL(st.FieldGoalsMade * 3, 0)) as TotalPoints
             FROM Football.FantasyTeam ft
             JOIN Football.FantasyTeamPlayer ftp ON ft.FantasyTeamID = ftp.FantasyTeamID
             JOIN Football.Player p ON ftp.PlayerID = p.PlayerID
             LEFT JOIN Football.Offense o ON p.PlayerID = o.PlayerID
             LEFT JOIN Football.Game g ON o.GameID = g.GameID
             LEFT JOIN Football.SpecialTeams st ON p.PlayerID = st.PlayerID AND st.GameID = g.GameID
             WHERE YEAR(g.[Date]) = @Year
             GROUP BY ft.FantasyTeamID, ft.FantasyTeamName;
         """;

        public static readonly string GetFantasyTeamTotalPointsBySeason = """
              SELECT 
                  ft.FantasyTeamID as UserID,
                  ft.FantasyTeamName,
                  SUM(ISNULL(o.Touchdowns, 0) * 6 + 
                      ISNULL(st.FieldGoalsMade, 0) * 3 + 
                      ISNULL(st.ExtraPointsMade, 0)) as TotalPoints
              FROM Football.FantasyTeam ft
                  JOIN Football.FantasyTeamPlayer ftp ON ft.FantasyTeamID = ftp.FantasyTeamID
                  JOIN Football.Player p ON ftp.PlayerID = p.PlayerID
                  LEFT JOIN Football.Offense o ON p.PlayerID = o.PlayerID
                  LEFT JOIN Football.SpecialTeams st ON p.PlayerID = st.PlayerID
                  LEFT JOIN Football.Game g ON o.GameID = g.GameID OR st.GameID = g.GameID
              WHERE YEAR(g.[Date]) = @Year
              GROUP BY ft.FantasyTeamID, ft.FantasyTeamName
          """;

        public static readonly string GetFantasyTeamPerformanceBySeason = """
              SELECT 
                  ft.FantasyTeamID,
                  ft.FantasyTeamName,
                  ft.Wins,
                  ft.Losses,
                  p.Name as PlayerName,
                  ftp.PositionID,
                  COALESCE(SUM(ISNULL(o.Touchdowns * 6, 0) + ISNULL(st.FieldGoalsMade * 3, 0)), 0) as PlayerPoints
              FROM Football.FantasyTeam ft
              JOIN Football.FantasyTeamPlayer ftp ON ft.FantasyTeamID = ftp.FantasyTeamID
              JOIN Football.Player p ON ftp.PlayerID = p.PlayerID
              LEFT JOIN Football.Offense o ON p.PlayerID = o.PlayerID
              LEFT JOIN Football.Game g ON o.GameID = g.GameID
              LEFT JOIN Football.SpecialTeams st ON p.PlayerID = st.PlayerID AND st.GameID = g.GameID
              WHERE YEAR(g.[Date]) = @Year OR g.[Date] IS NULL
              GROUP BY ft.FantasyTeamID, ft.FantasyTeamName, ft.Wins, ft.Losses, p.Name, ftp.PositionID
              HAVING COALESCE(SUM(ISNULL(o.Touchdowns * 6, 0) + ISNULL(st.FieldGoalsMade * 3, 0)), 0) >= 0;
          """;

        public static readonly string GetTeamAveragePerformance = """
            SELECT 
                ft.FantasyTeamID,
                ft.FantasyTeamName,
                -- Offense Averages
                AVG(o.PassingYards) AS AveragePassingYards,
                CAST(AVG(CAST(o.PassingAttempts AS DECIMAL(8,1))) AS INT) AS AveragePassingAttempts,
                AVG(o.RushingYards) AS AverageRushingYards,
                CAST(AVG(CAST(o.Carries AS DECIMAL(8,1))) AS INT) AS AverageCarries,
                AVG(o.ReceivingYards) AS AverageReceivingYards,
                CAST(AVG(CAST(o.Receptions AS DECIMAL(8,1))) AS INT) AS AverageReceptions,
                CAST(AVG(CAST(o.Touchdowns AS DECIMAL(8,1))) AS INT) AS AverageTouchdowns,
                -- Defense Averages
                CAST(AVG(CAST(d.Tackles AS DECIMAL(8,1))) AS INT) AS AverageTackles,
                CAST(AVG(CAST(d.Sacks AS DECIMAL(8,1))) AS INT) AS AverageSacks,
                CAST(AVG(CAST(d.Interceptions AS DECIMAL(8,1))) AS INT) AS AverageInterceptions,
                CAST(AVG(CAST(d.ForcedFumbles AS DECIMAL(8,1))) AS INT) AS AverageForcedFumbles,
                -- Special Teams Averages
                CAST(AVG(CAST(st.FieldGoalsMade AS DECIMAL(8,1))) AS INT) AS AverageFieldGoals,
                CAST(AVG(CAST(st.ExtraPointsMade AS DECIMAL(8,1))) AS INT) AS AverageExtraPoints,
                AVG(st.ReturnYards) AS AverageReturnYards,
                CAST(AVG(CAST(st.ReturnAttempts AS DECIMAL(8,1))) AS INT) AS AverageReturnAttempts
            FROM Football.FantasyTeam ft
                JOIN Football.FantasyTeamPlayer ftp ON ft.FantasyTeamID = ftp.FantasyTeamID
                JOIN Football.Player p ON ftp.PlayerID = p.PlayerID
                LEFT JOIN Football.Offense o ON p.PlayerID = o.PlayerID
                LEFT JOIN Football.Defense d ON p.PlayerID = d.PlayerID
                LEFT JOIN Football.SpecialTeams st ON p.PlayerID = st.PlayerID
                LEFT JOIN Football.Game g ON o.GameID = g.GameID OR d.GameID = g.GameID OR st.GameID = g.GameID
            WHERE YEAR(g.[Date]) = @Year
            GROUP BY ft.FantasyTeamID, ft.FantasyTeamName;
        """;
    }
}
