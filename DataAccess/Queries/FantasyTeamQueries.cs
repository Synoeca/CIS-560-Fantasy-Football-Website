namespace DataAccess.Queries
{
    public static class FantasyTeamQueries
    {
        public static readonly string GetAllFantasyTeams = "SELECT * FROM Football.FantasyTeam";

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
                CASE WHEN @SortOrder = 'name' THEN FantasyTeamName END,
                CASE WHEN @SortOrder = 'name_desc' THEN FantasyTeamName END DESC
            OFFSET @Offset ROWS 
            FETCH NEXT @PageSize ROWS ONLY
         """;
    }
}