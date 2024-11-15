using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories
{
    public class SpecialTeamsRepository
    {
        private readonly string _connectionString;

        public SpecialTeamsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<SpecialTeams> GetSpecialTeamsStatsByPlayerId(int playerId)
        {
            List<SpecialTeams> specialTeamsStats = [];
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
                        ExtraPointsMade = Convert.ToInt32(reader["ExtraPointsMade"]),
                        ExtraPointsAttempted = Convert.ToInt32(reader["ExtraPointsAttempted"]),
                        ReturnYards = Convert.ToSingle(reader["ReturnYards"]),
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
    }
}