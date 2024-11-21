using DataAccess.Models;
using DataAccess.Queries;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class TeamRepository
    {
        private readonly string _connectionString;

        public TeamRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetTeamNameById(int teamId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(TeamQueries.GetTeamNameById, connection);
                command.Parameters.AddWithValue("@TeamID", teamId);
                return Convert.ToString(command.ExecuteScalar()) ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public IEnumerable<Team> GetAllTeams()
        {
            List<Team> teams = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(TeamQueries.GetAllTeams, connection);
                using SqlDataReader? reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Team team = new(
                        Convert.ToInt32(reader["TeamID"]),
                        reader["SchoolName"] is DBNull ? string.Empty : Convert.ToString(reader["SchoolName"]),
                        reader["TeamName"] is DBNull ? string.Empty : Convert.ToString(reader["TeamName"]),
                        reader["City"] is DBNull ? string.Empty : Convert.ToString(reader["City"]),
                        reader["State"] is DBNull ? string.Empty : Convert.ToString(reader["State"])
                    );
                    teams.Add(team);
                }
                return teams;
            }
            catch
            {
                return Enumerable.Empty<Team>();
            }
        }
    }
}