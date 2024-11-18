namespace DataAccess.Queries
{
    public static class FantasyTeamPlayerQueries
    {
        public static readonly string GetAllFantasyTeamPlayers =
            "SELECT * FROM Football.FantasyTeamPlayer";

        public static readonly string AddPlayerToTeam = """              
            UPDATE Football.FantasyTeamPlayer
            SET FantasyTeamID = @FantasyTeamID
            WHERE PlayerID = @PlayerID;
            
            IF @@ROWCOUNT = 0
            BEGIN
                -- Insert a new record with PositionID provided
                INSERT INTO Football.FantasyTeamPlayer (PlayerID, FantasyTeamID, PositionID)
                VALUES (@PlayerID, @FantasyTeamID, @PositionID);
            END
        """;

        public static readonly string GetFilteredAvailablePlayers = """
            SELECT 
                p.PlayerID,
                ftp.PositionID,
                COUNT(*) OVER() as TotalCount
            FROM Football.Player p
            LEFT JOIN Football.FantasyTeamPlayer ftp ON p.PlayerID = ftp.PlayerID
            WHERE ftp.FantasyTeamID IS NULL
                AND (@SearchString = '' OR p.Name LIKE '%' + @SearchString + '%')
                AND (@PositionFilter = '' OR ftp.PositionID = @PositionFilter)
            ORDER BY
                CASE @SortOrder 
                    WHEN 'name' THEN p.Name 
                END ASC,
                CASE @SortOrder 
                    WHEN 'name_desc' THEN p.Name
                END DESC,
                CASE @SortOrder 
                    WHEN 'position' THEN ftp.PositionID
                END ASC,
                CASE @SortOrder 
                    WHEN 'position_desc' THEN ftp.PositionID
                END DESC
            OFFSET @Offset ROWS 
            FETCH NEXT @PageSize ROWS ONLY
        """;

        public static readonly string GetAvailablePlayers = """
            SELECT p.PlayerID, ftp.PositionID
            FROM Football.Player p
            LEFT JOIN Football.FantasyTeamPlayer ftp ON p.PlayerID = ftp.PlayerID
            WHERE ftp.FantasyTeamID IS NULL
        """;

        public static readonly string ValidatePlayerAvailability = """
            SELECT COUNT(*)
            FROM Football.Player p
            LEFT JOIN Football.FantasyTeamPlayer ftp ON p.PlayerID = ftp.PlayerID
            WHERE p.PlayerID = @PlayerID
                AND ftp.FantasyTeamID IS NULL
        """;
    }
}