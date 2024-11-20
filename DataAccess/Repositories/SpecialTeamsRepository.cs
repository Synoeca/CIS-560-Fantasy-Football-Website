using DataAccess.Models;
using DataAccess.Queries;
using System.Data.SqlClient;

public class SpecialTeamsRepository
{
    private readonly string _connectionString;

    public SpecialTeamsRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<SpecialTeams>? GetSpecialTeamsStatsByPlayerId(int playerId)
    {
        List<SpecialTeams>? specialTeamsStats = [];
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(SpecialTeamsQueries.GetSpecialTeamsStatsByPlayerId, connection);
            command.Parameters.AddWithValue("@PlayerID", playerId);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                specialTeamsStats.Add(new SpecialTeams
                {
                    PlayerID = Convert.ToInt32(reader["PlayerID"]),
                    GameID = Convert.ToInt32(reader["GameID"]),
                    FieldGoalsMade = Convert.ToInt32(reader["FieldGoalsMade"]),
                    FieldGoalsAttempted = Convert.ToInt32(reader["FieldGoalsAttempted"]),
                    ReturnYards = reader["ReturnYards"] is DBNull ? 0f : Convert.ToSingle(reader["ReturnYards"]),
                    ReturnAttempts = Convert.ToInt32(reader["ReturnAttempts"])
                });
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Repository error: {ex.Message}");
        }

        return specialTeamsStats;
    }

    // Add CRUD operations
    public int InsertSpecialTeamsStats(SpecialTeams stats)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(SpecialTeamsQueries.InsertSpecialTeamsStats, connection);

            command.Parameters.AddWithValue("@PlayerID", stats.PlayerID);
            command.Parameters.AddWithValue("@GameID", stats.GameID);
            command.Parameters.AddWithValue("@FieldGoalsMade", stats.FieldGoalsMade);
            command.Parameters.AddWithValue("@FieldGoalsAttempted", stats.FieldGoalsAttempted);
            command.Parameters.AddWithValue("@ReturnYards", stats.ReturnYards);
            command.Parameters.AddWithValue("@ReturnAttempts", stats.ReturnAttempts);

            return command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error inserting special teams stats: {ex.Message}");
        }
    }

    public bool UpdateSpecialTeamsStats(SpecialTeams? stats)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(SpecialTeamsQueries.UpdateSpecialTeamsStats, connection);

            command.Parameters.AddWithValue("@PlayerID", stats.PlayerID);
            command.Parameters.AddWithValue("@GameID", stats.GameID);
            command.Parameters.AddWithValue("@FieldGoalsMade", stats.FieldGoalsMade);
            command.Parameters.AddWithValue("@FieldGoalsAttempted", stats.FieldGoalsAttempted);
            command.Parameters.AddWithValue("@ExtraPointsMade", stats.ExtraPointsMade ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ExtraPointsAttempted",
                stats.ExtraPointsAttempted ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ReturnYards", stats.ReturnYards);
            command.Parameters.AddWithValue("@ReturnAttempts", stats.ReturnAttempts);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating special teams stats: {ex.Message}");
        }
    }

    public bool DeleteSpecialTeamsStats(int playerId, int gameId)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(SpecialTeamsQueries.DeleteSpecialTeamsStats, connection);

            command.Parameters.AddWithValue("@PlayerID", playerId);
            command.Parameters.AddWithValue("@GameID", gameId);

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting special teams stats: {ex.Message}");
        }
    }

    public SpecialTeams? GetSpecialTeamsStatsByPlayerAndGame(int playerId, int gameId)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(SpecialTeamsQueries.GetSpecialTeamsStatsByPlayerAndGame, connection);

            command.Parameters.AddWithValue("@PlayerID", playerId);
            command.Parameters.AddWithValue("@GameID", gameId);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new SpecialTeams
                {
                    PlayerID = Convert.ToInt32(reader["PlayerID"]),
                    GameID = Convert.ToInt32(reader["GameID"]),
                    FieldGoalsMade = Convert.ToInt32(reader["FieldGoalsMade"]),
                    FieldGoalsAttempted = Convert.ToInt32(reader["FieldGoalsAttempted"]),
                    ExtraPointsMade = reader["ExtraPointsMade"] is DBNull
                        ? null
                        : Convert.ToInt32(reader["ExtraPointsMade"]),
                    ExtraPointsAttempted = reader["ExtraPointsAttempted"] is DBNull
                        ? null
                        : Convert.ToInt32(reader["ExtraPointsAttempted"]),
                    ReturnYards = reader["ReturnYards"] is DBNull ? 0f : Convert.ToSingle(reader["ReturnYards"]),
                    ReturnAttempts = Convert.ToInt32(reader["ReturnAttempts"])
                };
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving special teams stats: {ex.Message}");
        }
    }
}