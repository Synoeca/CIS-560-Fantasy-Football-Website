namespace DataAccess.Queries
{
	public static class PositionQueries
	{
		public static readonly string GetAllPositions = "SELECT * FROM Football.Position";

        public static readonly string GetPositionNameById = """
            SELECT PositionName 
            FROM Football.Position 
            WHERE PositionID = @PositionID
        """;

        public static readonly string GetPositionIdByPlayerId = """
            SELECT PositionID
            FROM Football.FantasyTeamPlayer
            WHERE PlayerID = @PlayerID
        """;
    }
}
