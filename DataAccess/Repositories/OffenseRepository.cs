using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories
{
    public class OffenseRepository
    {
        private readonly string _connectionString;

        public OffenseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Offense> GetOffenseStatsByPlayerId(int playerId)
        {
            List<Offense> offenseStats = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(OffenseQueries.GetOffenseStatsByPlayerId, connection);
                command.Parameters.AddWithValue("@PlayerID", playerId);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    offenseStats.Add(new Offense
                    {
                        PlayerID = Convert.ToInt32(reader["PlayerID"]),
                        GameID = Convert.ToInt32(reader["GameID"]),
                        PassingYards = Convert.ToSingle(reader["PassingYards"]),
                        PassingAttempts = Convert.ToInt32(reader["PassingAttempts"]),
                        RushingYards = Convert.ToSingle(reader["RushingYards"]),
                        Carries = Convert.ToInt32(reader["Carries"]),
                        ReceivingYards = Convert.ToSingle(reader["ReceivingYards"]),
                        Receptions = Convert.ToInt32(reader["Receptions"]),
                        Touchdowns = Convert.ToInt32(reader["Touchdowns"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Repository error: {ex.Message}");
            }
            return offenseStats;
        }
    }
}