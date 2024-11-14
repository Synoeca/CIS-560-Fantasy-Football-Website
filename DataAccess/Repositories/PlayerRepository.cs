﻿using System.Data;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories
{
    public class PlayerRepository
    {
        private readonly string _connectionString;

        public PlayerRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string is empty");
            }
            _connectionString = connectionString;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            List<Player> players = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(PlayerQueries.GetAllPlayers, connection);
                using SqlDataReader? reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Player player = new()
                    {
                        PlayerID = Convert.ToInt32(reader["PlayerID"]),
                        Name = Convert.ToString(reader["Name"]) ?? string.Empty,
                        TeamID = Convert.ToInt32(reader["TeamID"]),
                        Class = Convert.ToString(reader["Class"]) ?? string.Empty,
                        HealthStatus = Convert.ToString(reader["HealthStatus"]) ?? string.Empty,
                        BenchStatus = Convert.ToString(reader["BenchStatus"]) ?? string.Empty
                    };
                    players.Add(player);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Repository error: {ex.Message}\nConnection string: {_connectionString}");
            }
            return players;
        }

        public IEnumerable<Player> GetPaginatedPlayers(int pageNumber, int pageSize)
        {
            List<Player> players = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(PlayerQueries.GetPlayersOrdered, connection);

                command.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                command.Parameters.AddWithValue("@PageSize", pageSize);

                using SqlDataReader? reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Player player = new()
                    {
                        PlayerID = Convert.ToInt32(reader["PlayerID"]),
                        Name = Convert.ToString(reader["Name"]) ?? string.Empty,
                        TeamID = Convert.ToInt32(reader["TeamID"]),
                        Class = Convert.ToString(reader["Class"]) ?? string.Empty,
                        HealthStatus = Convert.ToString(reader["HealthStatus"]) ?? string.Empty,
                        BenchStatus = Convert.ToString(reader["BenchStatus"]) ?? string.Empty
                    };
                    players.Add(player);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Repository error: {ex.Message}");
            }
            return players;
        }

        public int GetFilteredPlayersCount(string? searchString, string? teamFilter, string? classFilter, string? statusFilter)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(PlayerQueries.GetFilteredPlayersCount, connection);

                command.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(searchString) ? DBNull.Value : searchString);
                command.Parameters.AddWithValue("@TeamID", string.IsNullOrEmpty(teamFilter) ? DBNull.Value : int.Parse(teamFilter));
                command.Parameters.AddWithValue("@Class", string.IsNullOrEmpty(classFilter) ? DBNull.Value : classFilter);
                command.Parameters.AddWithValue("@BenchStatus", string.IsNullOrEmpty(statusFilter) ? DBNull.Value : statusFilter);

                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception($"Repository error: {ex.Message}");
            }
        }

        public IEnumerable<Player> GetFilteredPlayers(
            string? searchString,
            string? teamFilter,
            string? classFilter,
            string? statusFilter,
            string? sortOrder,
            int pageNumber,
            int pageSize)
        {
            List<Player> players = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();

                if (string.IsNullOrEmpty(searchString) &&
                    string.IsNullOrEmpty(teamFilter) &&
                    string.IsNullOrEmpty(classFilter) &&
                    string.IsNullOrEmpty(statusFilter) &&
                    string.IsNullOrEmpty(sortOrder))
                {
                    return GetPaginatedPlayers(pageNumber, pageSize);
                }

                string sortDirection = sortOrder?.EndsWith("_desc") == true ? "DESC" : "ASC";
                string sortColumn = sortOrder?.Split('_')[0] ?? "id";

                string query = string.Format(PlayerQueries.GetFilteredPlayers, sortDirection);

                using SqlCommand command = new(query, connection);

                command.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(searchString) ? DBNull.Value : searchString);
                command.Parameters.AddWithValue("@TeamID", string.IsNullOrEmpty(teamFilter) ? DBNull.Value : int.Parse(teamFilter));
                command.Parameters.AddWithValue("@Class", string.IsNullOrEmpty(classFilter) ? DBNull.Value : classFilter);
                command.Parameters.AddWithValue("@BenchStatus", string.IsNullOrEmpty(statusFilter) ? DBNull.Value : statusFilter);
                command.Parameters.AddWithValue("@SortColumn", sortColumn);
                command.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                command.Parameters.AddWithValue("@PageSize", pageSize);

                using SqlDataReader? reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Player player = new()
                    {
                        PlayerID = Convert.ToInt32(reader["PlayerID"]),
                        Name = Convert.ToString(reader["Name"]) ?? string.Empty,
                        TeamID = Convert.ToInt32(reader["TeamID"]),
                        Class = Convert.ToString(reader["Class"]) ?? string.Empty,
                        HealthStatus = Convert.ToString(reader["HealthStatus"]) ?? string.Empty,
                        BenchStatus = Convert.ToString(reader["BenchStatus"]) ?? string.Empty
                    };
                    players.Add(player);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Repository error: {ex.Message}");
            }
            return players;
        }
    }
}