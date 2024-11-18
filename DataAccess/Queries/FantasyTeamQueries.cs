namespace DataAccess.Queries
{
    public static class FantasyTeamQueries
    {
        // Team Management Queries
        public static readonly string GetAllFantasyTeams =
            "SELECT * FROM Football.FantasyTeam";

        public static readonly string GetFilteredFantasyTeamsCount = """
             SELECT COUNT(*) 
             FROM Football.FantasyTeam 
             WHERE (@SearchString IS NULL OR FantasyTeamName LIKE '%' + @SearchString + '%')
         """;

        public static readonly string GetFilteredFantasyTeams = """
            SELECT * 
            FROM Football.FantasyTeam 
            WHERE (@SearchString IS NULL OR FantasyTeamName LIKE '%' + @SearchString + '%')
            ORDER BY 
                CASE WHEN @SortOrder = 'name' THEN FantasyTeamName END ASC,
                CASE WHEN @SortOrder = 'name_desc' THEN FantasyTeamName END DESC,
                CASE WHEN @SortOrder = 'wins' THEN Wins END ASC,
                CASE WHEN @SortOrder = 'wins_desc' THEN Wins END DESC,
                CASE WHEN @SortOrder = 'losses' THEN Losses END ASC,
                CASE WHEN @SortOrder = 'losses_desc' THEN Losses END DESC,
                CASE WHEN @SortOrder = '' OR @SortOrder IS NULL THEN FantasyTeamID END ASC
            OFFSET @Offset ROWS 
            FETCH NEXT @PageSize ROWS ONLY
        """;

        public static readonly string GetFantasyTeamById = """
            SELECT FantasyTeamID, FantasyTeamName, Wins, Losses 
            FROM Football.FantasyTeam 
            WHERE FantasyTeamID = @FantasyTeamID
        """;

        public static readonly string UpdateFantasyTeam = """
            UPDATE Football.FantasyTeam 
            SET FantasyTeamName = @FantasyTeamName, 
                Wins = @Wins, 
                Losses = @Losses 
            WHERE FantasyTeamID = @FantasyTeamID
        """;

        public static readonly string CreateFantasyTeam = """
              INSERT INTO Football.FantasyTeam (FantasyTeamName, Wins, Losses, DraftStatus) 
              VALUES (@FantasyTeamName, @Wins, @Losses, 'Not Started');
              SELECT SCOPE_IDENTITY();
          """;

        public static readonly string DeleteFantasyTeam = """
              DELETE FROM Football.FantasyTeamPlayer 
              WHERE FantasyTeamID = @FantasyTeamID;
              
              DELETE FROM Football.FantasyTeam 
              WHERE FantasyTeamID = @FantasyTeamID;
          """;

        // Draft Status Queries
        public static readonly string IsDraftInProgress = """
            SELECT IsDraftInProgress 
            FROM Football.DraftStatus 
            WHERE DraftStatusID = 1
        """;

        public static readonly string GetCurrentDraftRound = """
            SELECT CurrentRound 
            FROM Football.DraftStatus 
            WHERE DraftStatusID = 1
        """;

        public static readonly string GetCurrentDraftPosition = """
            SELECT CurrentPosition 
            FROM Football.DraftStatus 
            WHERE DraftStatusID = 1
        """;

        public static readonly string GetCurrentDraftingTeam = """
            SELECT CASE 
                WHEN IsDraftInProgress = 1 THEN CurrentDraftingTeamID
                ELSE 0 
            END as CurrentDraftingTeamID
            FROM Football.DraftStatus 
            WHERE DraftStatusID = 1
        """;

        public static readonly string GetDraftStatus = """
            SELECT 
                ds.IsDraftInProgress,
                ds.CurrentRound,
                ds.CurrentPosition,
                ds.TotalTeams,
                ft.FantasyTeamID as CurrentDraftingTeamID,
                ft.FantasyTeamName as CurrentDraftingTeamName
            FROM Football.DraftStatus ds
            LEFT JOIN Football.FantasyTeam ft ON ds.CurrentPosition = ft.FantasyTeamID
            WHERE ds.DraftStatusID = 1
        """;

        // Draft Operation Queries
        public static readonly string StartDraft = """
            UPDATE Football.DraftStatus 
            SET IsDraftInProgress = 1, 
                CurrentRound = 1, 
                CurrentPosition = 1 
            WHERE DraftStatusID = 1;
            
            UPDATE Football.FantasyTeam 
            SET DraftStatus = 'In Progress'
        """;

        public static readonly string MoveToDraftPosition = """
            DECLARE @TotalTeams INT = (SELECT TotalTeams FROM Football.DraftStatus WHERE DraftStatusID = 1)
            DECLARE @CurrentPosition INT = (SELECT CurrentPosition FROM Football.DraftStatus WHERE DraftStatusID = 1)
            DECLARE @CurrentRound INT = (SELECT CurrentRound FROM Football.DraftStatus WHERE DraftStatusID = 1)
            
            IF @CurrentPosition = @TotalTeams
            BEGIN
                -- Move to next round
                UPDATE Football.DraftStatus 
                SET CurrentRound = @CurrentRound + 1,
                    CurrentPosition = 1
                WHERE DraftStatusID = 1
            END
            ELSE
            BEGIN
                -- Move to next position
                UPDATE Football.DraftStatus 
                SET CurrentPosition = @CurrentPosition + 1
                WHERE DraftStatusID = 1
            END
        """;

        public static readonly string EndDraft = """
            UPDATE Football.DraftStatus 
            SET IsDraftInProgress = 0, 
                CurrentRound = 0, 
                CurrentPosition = 0 
            WHERE DraftStatusID = 1;
            
            UPDATE Football.FantasyTeam 
            SET DraftStatus = 'Completed'
        """;

        public static readonly string UpdateDraftRound = """
             UPDATE Football.DraftStatus
             SET CurrentRound = @NewRound
         """;

        public static readonly string UpdateCurrentDraftingTeam = """
              UPDATE Football.DraftStatus
              SET CurrentDraftingTeamID = @CurrentDraftingTeamID
          """;

        public static readonly string GetTotalTeams = """
              SELECT COUNT(*) 
              FROM Football.FantasyTeam
          """;
    }
}