namespace DataAccess.Queries;

public static class SpecialTeamsQueries
{
    public static readonly string GetSpecialTeamsStatsByPlayerId = """
           SELECT * FROM Football.SpecialTeams 
           WHERE PlayerID = @PlayerID
       """;

    public static readonly string GetSpecialTeamsStatsByPlayerAndGame = """
            SELECT * FROM Football.SpecialTeams 
            WHERE PlayerID = @PlayerID AND GameID = @GameID
        """;

    public static readonly string InsertSpecialTeamsStats = """
            INSERT INTO Football.SpecialTeams 
            (PlayerID, GameID, FieldGoalsMade, FieldGoalsAttempted, 
             ExtraPointsMade, ExtraPointsAttempted, ReturnYards, ReturnAttempts)
            VALUES 
            (@PlayerID, @GameID, @FieldGoalsMade, @FieldGoalsAttempted,
             @ExtraPointsMade, @ExtraPointsAttempted, @ReturnYards, @ReturnAttempts)
        """;

    public static readonly string UpdateSpecialTeamsStats = """
            UPDATE Football.SpecialTeams
            SET FieldGoalsMade = @FieldGoalsMade,
                FieldGoalsAttempted = @FieldGoalsAttempted,
                ExtraPointsMade = @ExtraPointsMade,
                ExtraPointsAttempted = @ExtraPointsAttempted,
                ReturnYards = @ReturnYards,
                ReturnAttempts = @ReturnAttempts
            WHERE PlayerID = @PlayerID AND GameID = @GameID
        """;

    public static readonly string DeleteSpecialTeamsStats = """
            DELETE FROM Football.SpecialTeams
            WHERE PlayerID = @PlayerID AND GameID = @GameID
        """;

    public static readonly string GetAllSpecialTeamsStats = "SELECT * FROM Football.SpecialTeams";

    public static readonly string GetSpecialTeamsByGameId = """
            SELECT * FROM Football.SpecialTeams
            WHERE GameID = @GameID
        """;
}