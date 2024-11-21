using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories
{
    public class DefenseRepository
    {
        private readonly string _connectionString;

        public DefenseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Defense>? GetDefenseStatsByPlayerId(int playerId)
        {
            List<Defense>? defenseStats = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(DefenseQueries.GetDefenseStatsByPlayerId, connection);
                command.Parameters.AddWithValue("@PlayerID", playerId);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    defenseStats.Add(new Defense
                    {
                        PlayerID = Convert.ToInt32(reader["PlayerID"]),
                        GameID = Convert.ToInt32(reader["GameID"]),
                        Interceptions = reader["Interceptions"] is DBNull ? 0 : Convert.ToInt32(reader["Interceptions"]),
                        Sacks = reader["Sacks"] is DBNull ? 0 : Convert.ToInt32(reader["Sacks"]),
                        ForcedFumbles = reader["ForcedFumbles"] is DBNull ? 0 : Convert.ToInt32(reader["ForcedFumbles"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Repository error: {ex.Message}");
            }
            return defenseStats;
        }

        public void InsertDefense(Defense defense)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(DefenseQueries.InsertDefense, connection);

                command.Parameters.AddWithValue("@PlayerID", defense.PlayerID);
                command.Parameters.AddWithValue("@GameID", defense.GameID);
                command.Parameters.AddWithValue("@Interceptions", defense.Interceptions);
                command.Parameters.AddWithValue("@Sacks", defense.Sacks);
                command.Parameters.AddWithValue("@ForcedFumbles", defense.ForcedFumbles);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting defense stats: {ex.Message}");
            }
        }

        public Defense GetDefenseByPlayerAndGame(int playerId, int gameId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(DefenseQueries.GetDefenseByPlayerAndGame, connection);
                command.Parameters.AddWithValue("@PlayerID", playerId);
                command.Parameters.AddWithValue("@GameID", gameId);
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Defense
                    {
                        PlayerID = Convert.ToInt32(reader["PlayerID"]),
                        GameID = Convert.ToInt32(reader["GameID"]),
                        Interceptions = reader["Interceptions"] is DBNull ? 0 : Convert.ToInt32(reader["Interceptions"]),
                        Tackles = reader["Tackles"] is DBNull ? 0 : Convert.ToInt32(reader["Tackles"]),
                        Sacks = reader["Sacks"] is DBNull ? 0 : Convert.ToInt32(reader["Sacks"]),
                        ForcedFumbles = reader["ForcedFumbles"] is DBNull ? 0 : Convert.ToInt32(reader["ForcedFumbles"])
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving defense stats: {ex.Message}");
            }
        }

        public void UpdateDefense(Defense defense)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(DefenseQueries.UpdateDefense, connection);

                command.Parameters.AddWithValue("@PlayerID", defense.PlayerID);
                command.Parameters.AddWithValue("@GameID", defense.GameID);
                command.Parameters.AddWithValue("@Interceptions", defense.Interceptions);
                command.Parameters.AddWithValue("@Tackles", defense.Tackles);
                command.Parameters.AddWithValue("@Sacks", defense.Sacks);
                command.Parameters.AddWithValue("@ForcedFumbles", defense.ForcedFumbles);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating defense stats: {ex.Message}");
            }
        }

        public void DeleteDefense(int playerId, int gameId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(DefenseQueries.DeleteDefense, connection);
                command.Parameters.AddWithValue("@PlayerID", playerId);
                command.Parameters.AddWithValue("@GameID", gameId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting defense stats: {ex.Message}");
            }
        }
    }
}