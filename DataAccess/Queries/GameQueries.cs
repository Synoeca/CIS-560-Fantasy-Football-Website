﻿namespace DataAccess.Queries;

public static class GameQueries
{
    public static readonly string GetAllGames = """
            SELECT GameID, HomeTeam, AwayTeam, Date, Week, HomeTeamScore, AwayTeamScore 
            FROM Football.Game
        """;

    public static readonly string InsertGame = """
           INSERT INTO Football.Game (HomeTeam, AwayTeam, Date, Week, HomeTeamScore, AwayTeamScore)
           VALUES (@HomeTeam, @AwayTeam, @Date, @Week, @HomeTeamScore, @AwayTeamScore);
           SELECT SCOPE_IDENTITY();
       """;

    public static readonly string UpdateGame = """
           UPDATE Football.Game
           SET HomeTeam = @HomeTeam,
               AwayTeam = @AwayTeam,
               Date = @Date,
               Week = @Week,
               HomeTeamScore = @HomeTeamScore,
               AwayTeamScore = @AwayTeamScore
           WHERE GameID = @GameID
       """;

    public static readonly string DeleteGame = """
           DELETE FROM Football.Game
           WHERE GameID = @GameID
       """;

    public static readonly string GetGameById = """
            SELECT GameID, HomeTeam, AwayTeam, Date, Week, HomeTeamScore, AwayTeamScore
            FROM Football.Game
            WHERE GameID = @GameID
        """;

    public static readonly string DeleteSpecialTeamsForGame = """
          DELETE FROM Football.SpecialTeams
          WHERE GameID = @GameID
      """;

    public static readonly string DeleteSeasonsForGame = """
         DELETE FROM Football.Seasons
         WHERE GameID = @GameID
     """;

    public static readonly string DeleteOffenseForGame = """
         DELETE FROM Football.Offense
         WHERE GameID = @GameID
     """;

    public static readonly string DeleteDefenseForGame = """
            DELETE FROM Football.Defense
            WHERE GameID = @GameID
        """;
}