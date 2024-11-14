﻿namespace DataAccess.Queries
{
	public static class PlayerQueries
	{
		public static readonly string GetAllPlayers = "SELECT * FROM Football.Player";

        public static readonly string GetFilteredPlayersCount = """
                                                                    SELECT COUNT(*) 
                                                                    FROM Football.Player p
                                                                    WHERE 
                                                                        (@Name IS NULL OR p.Name LIKE '%' + @Name + '%') AND
                                                                        (@TeamID IS NULL OR p.TeamID = @TeamID) AND
                                                                        (@Class IS NULL OR p.Class = @Class) AND
                                                                        (@BenchStatus IS NULL OR p.BenchStatus = @BenchStatus)
                                                                """;

        public static readonly string GetFilteredPlayers = """
                                                               SELECT p.* 
                                                               FROM Football.Player p
                                                               WHERE 
                                                                   (@Name IS NULL OR p.Name LIKE '%' + @Name + '%') AND
                                                                   (@TeamID IS NULL OR p.TeamID = @TeamID) AND
                                                                   (@Class IS NULL OR p.Class = @Class) AND
                                                                   (@BenchStatus IS NULL OR p.BenchStatus = @BenchStatus)
                                                               ORDER BY 
                                                                   CASE @SortColumn 
                                                                       WHEN 'name' THEN p.Name
                                                                       WHEN 'class' THEN p.Class
                                                                       WHEN 'team' THEN CAST(p.TeamID as VARCHAR)
                                                                       ELSE CAST(p.PlayerID as VARCHAR)
                                                                   END {0},
                                                                   PlayerID {0}  -- Added secondary sort on PlayerID
                                                               OFFSET @Offset ROWS
                                                               FETCH NEXT @PageSize ROWS ONLY
                                                           """;

        public static readonly string GetPlayersOrdered = """
                                                              SELECT p.* 
                                                              FROM Football.Player p
                                                              ORDER BY PlayerID
                                                              OFFSET @Offset ROWS
                                                              FETCH NEXT @PageSize ROWS ONLY
                                                          """;
    }


    // Add more queries for other CRUD operations (INSERT, UPDATE, DELETE)
}