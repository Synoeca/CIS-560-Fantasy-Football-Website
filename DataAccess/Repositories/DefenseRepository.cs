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

        public List<Defense> GetDefenseStatsByPlayerId(int playerId)
        {
            List<Defense> defenseStats = [];
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
                        Interceptions = Convert.ToInt32(reader["Interceptions"]),
                        Tackles = Convert.ToInt32(reader["Tackles"]),
                        Sacks = Convert.ToInt32(reader["Sacks"]),
                        ForcedFumbles = Convert.ToInt32(reader["ForcedFumbles"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Repository error: {ex.Message}");
            }
            return defenseStats;
        }
    }
}