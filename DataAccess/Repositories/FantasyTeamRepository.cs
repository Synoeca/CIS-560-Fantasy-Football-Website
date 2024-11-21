using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(new FantasyTeam
                {
                    FantasyTeamID = reader.GetInt32(0),
                    FantasyTeamName = reader.GetString(1),
                    Wins = reader.GetInt32(2),
                    Losses = reader.GetInt32(3),
                    DraftStatus = reader.GetString(4)
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

                command.Parameters.AddWithValue("@SearchString",
                    string.IsNullOrEmpty(searchString) ? DBNull.Value : searchString);
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

            return null!;
        }

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
                return result != DBNull.Value ? (int)result : 0;
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

            SqlCommand command = new(FantasyTeamQueries.GetFantasyTeamById, connection);

            command.Parameters.AddWithValue("@FantasyTeamID", fantasyTeamId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                teamName = reader.GetString(reader.GetOrdinal("FantasyTeamName"));
            }

            return teamName;
        }

        public Dictionary<FantasyTeam, int> GetFantasyTeamPoints(int year)
        {
            Dictionary<FantasyTeam, int> teamPoints = [];

            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = new(AggregatingQueries.GetFantasyTeamPointsBySeason, connection);
            command.Parameters.AddWithValue("@Year", year);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                FantasyTeam team = new FantasyTeam
                {
                    FantasyTeamID = reader.GetInt32(0),
                    FantasyTeamName = reader.GetString(1)
                };

                int points = reader.GetInt32(2);
                teamPoints[team] = points;
            }

            return teamPoints;
        }

        public Dictionary<FantasyTeam, List<(string PlayerName, int Position, int Points)>>
            GetFantasyTeamPerformance(int year)
        {
            Dictionary<FantasyTeam, List<(string, int, int)>> teamPerformances = new();

            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = new(AggregatingQueries.GetFantasyTeamPerformanceBySeason, connection);
            command.Parameters.AddWithValue("@Year", year);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                FantasyTeam team = new()
                {
                    FantasyTeamID = reader.GetInt32(0),
                    FantasyTeamName = reader.GetString(1),
                    Wins = reader.GetInt32(2),
                    Losses = reader.GetInt32(3)
                };

                string playerName = reader.GetString(4);
                int position = reader.GetInt32(5);
                int points = reader.GetInt32(6);

                if (!teamPerformances.ContainsKey(team))
                {
                    teamPerformances[team] = [];
                }

                teamPerformances[team].Add((playerName, position, points));
            }

            return teamPerformances;
        }

        public Dictionary<int, (string TeamName, int TotalPoints)> GetFantasyTeamTotalPointsBySeason(int year)
        {
            Dictionary<int, (string TeamName, int TotalPoints)> teamTotalPoints = new();

            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = new(AggregatingQueries.GetFantasyTeamTotalPointsBySeason, connection);
            command.Parameters.AddWithValue("@Year", year);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int userId = reader.GetInt32(reader.GetOrdinal("UserID"));
                string teamName = reader.GetString(reader.GetOrdinal("FantasyTeamName"));
                int totalPoints = reader.GetInt32(reader.GetOrdinal("TotalPoints"));

                teamTotalPoints[userId] = (teamName, totalPoints);
            }

            return teamTotalPoints;
        }

        public Dictionary<FantasyTeam, (
            decimal PassYds, // DECIMAL(8,1)
            int PassAtt, // INT
            decimal RushYds, // DECIMAL(8,1)
            int Carries, // INT
            decimal RecYds, // DECIMAL(8,1)
            int Receptions, // INT
            int TDs, // INT
            int Tackles, // INT
            int Sacks, // INT
            int Ints, // INT
            int ForcedFumbles, // INT
            int FGs, // INT (FieldGoalsMade)
            int XPs, // INT (ExtraPointsMade)
            decimal ReturnYds, // DECIMAL(8,1)
            int ReturnAtt)> GetTeamAveragePerformance(int year)
        {
            Dictionary<FantasyTeam, (decimal, int, decimal, int, decimal, int, int, int, int, int, int, int, int, decimal, int)> performances = new();

            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = new(AggregatingQueries.GetTeamAveragePerformance, connection);
            command.Parameters.AddWithValue("@Year", year);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                FantasyTeam team = new FantasyTeam
                {
                    FantasyTeamID = reader.GetInt32(0),
                    FantasyTeamName = reader.GetString(1)
                };

                (decimal, int, decimal, int, decimal, int, int, int, int, int, int, int, int, decimal, int) stats = (
                    reader.IsDBNull(2) ? 0m : reader.GetDecimal(2), // PassYds (DECIMAL)
                    reader.IsDBNull(3) ? 0 : reader.GetInt32(3), // PassAtt (INT)
                    reader.IsDBNull(4) ? 0m : reader.GetDecimal(4), // RushYds (DECIMAL)
                    reader.IsDBNull(5) ? 0 : reader.GetInt32(5), // Carries (INT)
                    reader.IsDBNull(6) ? 0m : reader.GetDecimal(6), // RecYds (DECIMAL)
                    reader.IsDBNull(7) ? 0 : reader.GetInt32(7), // Receptions (INT)
                    reader.IsDBNull(8) ? 0 : reader.GetInt32(8), // TDs (INT)
                    reader.IsDBNull(9) ? 0 : reader.GetInt32(9), // Tackles (INT)
                    reader.IsDBNull(10) ? 0 : reader.GetInt32(10), // Sacks (INT)
                    reader.IsDBNull(11) ? 0 : reader.GetInt32(11), // Ints (INT)
                    reader.IsDBNull(12) ? 0 : reader.GetInt32(12), // ForcedFumbles (INT)
                    reader.IsDBNull(13) ? 0 : reader.GetInt32(13), // FGs (INT)
                    reader.IsDBNull(14) ? 0 : reader.GetInt32(14), // XPs (INT)
                    reader.IsDBNull(15) ? 0m : reader.GetDecimal(15), // ReturnYds (DECIMAL)
                    reader.IsDBNull(16) ? 0 : reader.GetInt32(16) // ReturnAtt (INT)
                );

                performances[team] = stats;
            }

            return performances;
        }
    }
}