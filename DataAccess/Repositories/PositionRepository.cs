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

		public IEnumerable<Position> GetAllPositions()
		{
			List<Position> positions = [];
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(PositionQueries.GetAllPositions, connection);
            connection.Open();
            SqlDataReader? reader = command.ExecuteReader();
            while (reader.Read())
            {
                positions.Add(new Position
                {
                    PositionID = reader.GetInt32(0),
                    PositionName = reader.GetString(1),
                    MinCount = reader.GetInt32(2),
                    MaxCount = reader.GetInt32(3)
                });
            }

            return positions;
		}

		// Add more methods for other CRUD operations (INSERT, UPDATE, DELETE)
	}
}