using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories
{
    public class FantasyTeamRepository
    {
        private readonly string _connectionString;

        public FantasyTeamRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<FantasyTeam> GetAllFantasyTeams()
        {
            List<FantasyTeam> teams = [];
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.GetAllFantasyTeams, connection);
            connection.Open();
            SqlDataReader? reader = command.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(new FantasyTeam
                {
                    FantasyTeamID = reader.GetInt32(0),
                    FantasyTeamName = reader.GetString(1),
                    PointsScored = reader.GetInt32(2),
                    Wins = reader.GetInt32(3),
                    Losses = reader.GetInt32(4)
                });
            }

            return teams;
        }

        public int GetFilteredFantasyTeamsCount(string searchString)
        {
            int count = 0;
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.GetFilteredFantasyTeamsCount, connection);
            command.Parameters.AddWithValue("@SearchString", string.IsNullOrEmpty(searchString) ? (object)DBNull.Value : searchString);

            connection.Open();
            count = (int)command.ExecuteScalar();
            return count;
        }

        public IEnumerable<FantasyTeam> GetFilteredFantasyTeams(string searchString, string sortOrder, int currentPage, int pageSize)
        {
            List<FantasyTeam> teams = [];
            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = new(FantasyTeamQueries.GetFilteredFantasyTeams, connection);
            command.Parameters.AddWithValue("@SearchString", string.IsNullOrEmpty(searchString) ? DBNull.Value : searchString);
            command.Parameters.AddWithValue("@SortOrder", sortOrder);
            command.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize);
            command.Parameters.AddWithValue("@PageSize", pageSize);

            connection.Open();
            using SqlDataReader? reader = command.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(new FantasyTeam
                {
                    FantasyTeamID = reader.GetInt32(0),
                    FantasyTeamName = reader.GetString(1),
                    PointsScored = reader.GetInt32(2),
                    Wins = reader.GetInt32(3),
                    Losses = reader.GetInt32(4)
                });
            }

            return teams;
        }

        // Add more methods for other CRUD operations (INSERT, UPDATE, DELETE)
    }
}