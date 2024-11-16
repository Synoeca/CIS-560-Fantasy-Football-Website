﻿public static class GameQueries
{
    public static readonly string GetAllGames = """
        SELECT GameID, HomeTeam, AwayTeam, Date, HomeTeamScore, AwayTeamScore 
        FROM Football.Game
    """;

    public static readonly string InsertGame = """
       INSERT INTO Football.Game (HomeTeam, AwayTeam, Date, HomeTeamScore, AwayTeamScore)
       VALUES (@HomeTeam, @AwayTeam, @Date, @HomeTeamScore, @AwayTeamScore);
       SELECT SCOPE_IDENTITY();
   """;

    public static readonly string UpdateGame = """
       UPDATE Football.Game
       SET HomeTeam = @HomeTeam,
           AwayTeam = @AwayTeam,
           Date = @Date,
           HomeTeamScore = @HomeTeamScore,
           AwayTeamScore = @AwayTeamScore
       WHERE GameID = @GameID
   """;

    public static readonly string DeleteGame = """
       DELETE FROM Football.Game
       WHERE GameID = @GameID
   """;

    public static readonly string GetGameById = """
        SELECT GameID, HomeTeam, AwayTeam, Date, HomeTeamScore, AwayTeamScore
        FROM Football.Game
        WHERE GameID = @GameID
    """;
}