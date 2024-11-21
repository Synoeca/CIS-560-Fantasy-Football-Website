using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories
{
    public class PositionRepository
    {
        private readonly string _connectionString;

        public PositionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Existing method to get all positions
        public IEnumerable<Position>? GetAllPositions()
        {
            List<Position>? positions = new();
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(PositionQueries.GetAllPositions, connection);
            connection.Open();
            SqlDataReader? reader = command.ExecuteReader();
            while (reader.Read())
            {
                positions.Add(new Position
                (
                    reader.GetInt32(0),
                    reader.GetString(1)
                ));
            }

            return positions;
        }

        // Existing method to get position name by ID
        public string GetPositionNameById(int positionId)
        {
            string positionName = string.Empty;
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(PositionQueries.GetPositionNameById, connection);
                command.Parameters.AddWithValue("@PositionID", positionId);
                positionName = (string)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving position name: {ex.Message}");
            }
            return positionName;
        }

        // New method to get PositionID by PlayerID
        public int GetPositionIdByPlayerId(int playerId)
        {
            int positionId = 0;
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(PositionQueries.GetPositionIdByPlayerId, connection);
                command.Parameters.AddWithValue("@PlayerID", playerId);
                object? result = command.ExecuteScalar();

                if (result != null)
                {
                    positionId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving position ID: {ex.Message}");
            }
            return positionId;
        }
    }
}
