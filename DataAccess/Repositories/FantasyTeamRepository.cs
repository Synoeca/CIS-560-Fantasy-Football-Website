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
            List<FantasyTeam> teams = new List<FantasyTeam>();
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.GetAllFantasyTeams, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(new FantasyTeam
                {
                    FantasyTeamID = reader.GetInt32(0),
                    FantasyTeamName = reader.GetString(1),
                    Wins = reader.GetInt32(2),
                    Losses = reader.GetInt32(3),
                    DraftStatus = reader.GetString(4) // Ensure this column exists in your query
                });
            }
            return teams;
        }

        public int GetFilteredFantasyTeamsCount(string searchString)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new(FantasyTeamQueries.GetFilteredFantasyTeamsCount, connection);

                command.Parameters.AddWithValue("@SearchString",
                    string.IsNullOrEmpty(searchString) ? DBNull.Value : searchString);

                connection.Open();
                return (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting filtered fantasy teams count: {ex.Message}", ex);
            }
        }

        public IEnumerable<FantasyTeam> GetFilteredFantasyTeams(
            string searchString,
            string sortOrder,
            int currentPage,
            int pageSize)
        {
            List<FantasyTeam> teams = [];

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new(FantasyTeamQueries.GetFilteredFantasyTeams, connection);

                // Ensure parameters are never null and properly formatted
                command.Parameters.AddWithValue("@SearchString", string.IsNullOrEmpty(searchString) ? DBNull.Value : searchString);
                command.Parameters.AddWithValue("@SortOrder", string.IsNullOrEmpty(sortOrder) ? "" : sortOrder);
                command.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize);
                command.Parameters.AddWithValue("@PageSize", pageSize);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    teams.Add(new FantasyTeam
                    {
                        FantasyTeamID = reader.GetInt32(0),
                        FantasyTeamName = reader.GetString(1),
                        Wins = reader.GetInt32(2),
                        Losses = reader.GetInt32(3)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving filtered fantasy teams: {ex.Message}", ex);
            }

            return teams;
        }

        public bool IsDraftInProgress()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.IsDraftInProgress, connection);
            connection.Open();
            return (bool)command.ExecuteScalar();
        }

        public int GetCurrentDraftRound()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.GetCurrentDraftRound, connection);
            connection.Open();
            return (int)command.ExecuteScalar();
        }

        public int GetCurrentDraftPosition()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.GetCurrentDraftPosition, connection);
            connection.Open();
            return (int)command.ExecuteScalar();
        }

        public void StartDraft()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.StartDraft, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void MoveToDraftPosition()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.MoveToDraftPosition, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void EndDraft()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.EndDraft, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }

        // Method to retrieve a fantasy team by ID
        public FantasyTeam GetFantasyTeamById(int fantasyTeamId)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.GetFantasyTeamById, connection);
            command.Parameters.AddWithValue("@FantasyTeamID", fantasyTeamId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new FantasyTeam
                {
                    FantasyTeamID = reader.GetInt32(0),
                    FantasyTeamName = reader.GetString(1),
                    Wins = reader.GetInt32(2),
                    Losses = reader.GetInt32(3)
                };
            }
            return null; // Return null if no team found
        }

        // Method to update a fantasy team's details
        public void UpdateFantasyTeam(FantasyTeam team)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.UpdateFantasyTeam, connection);

            command.Parameters.AddWithValue("@FantasyTeamID", team.FantasyTeamID);
            command.Parameters.AddWithValue("@FantasyTeamName", team.FantasyTeamName);
            command.Parameters.AddWithValue("@Wins", team.Wins);
            command.Parameters.AddWithValue("@Losses", team.Losses);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public int GetCurrentDraftingTeamId()
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                SqlCommand command = new(FantasyTeamQueries.GetCurrentDraftingTeam, connection);
                connection.Open();

                object? result = command.ExecuteScalar();
                return result != DBNull.Value ? (int)result : 0; // Return 0 if no current drafting team found
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting current drafting team: {ex.Message}");
            }
        }

        public void UpdateDraftRound(int newRound)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.UpdateDraftRound, connection);
            command.Parameters.AddWithValue("@NewRound", newRound);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void UpdateCurrentDraftingTeam(int teamId)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.UpdateCurrentDraftingTeam, connection);
            command.Parameters.AddWithValue("@CurrentDraftingTeamID", teamId);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public int GetTotalTeams()
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamQueries.GetTotalTeams, connection);
            connection.Open();
            return (int)command.ExecuteScalar();
        }

        public int CreateFantasyTeam(FantasyTeam team)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new(FantasyTeamQueries.CreateFantasyTeam, connection);

                command.Parameters.AddWithValue("@FantasyTeamName", team.FantasyTeamName);
                command.Parameters.AddWithValue("@Wins", team.Wins);
                command.Parameters.AddWithValue("@Losses", team.Losses);

                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating fantasy team: {ex.Message}", ex);
            }
        }

        public void DeleteFantasyTeam(int teamId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new(FantasyTeamQueries.DeleteFantasyTeam, connection);

                command.Parameters.AddWithValue("@FantasyTeamID", teamId);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting fantasy team: {ex.Message}", ex);
            }
        }

        public string GetFantasyTeamNameById(int fantasyTeamId)
        {
            string teamName = string.Empty;

            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("""
                                         SELECT FantasyTeamName 
                                         FROM Football.FantasyTeam 
                                         WHERE FantasyTeamID = @FantasyTeamID;
                                     """, connection);

            command.Parameters.AddWithValue("@FantasyTeamID", fantasyTeamId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                teamName = reader.GetString(reader.GetOrdinal("FantasyTeamName"));
            }

            return teamName;
        }
    }
}