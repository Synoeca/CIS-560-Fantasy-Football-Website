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
			var teams = new List<FantasyTeam>();
			using (var connection = new SqlConnection(_connectionString))
			{
				var command = new SqlCommand(FantasyTeamQueries.GetAllFantasyTeams, connection);
				connection.Open();
				var reader = command.ExecuteReader();
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
			}
			return teams;
		}

		// Add more methods for other CRUD operations (INSERT, UPDATE, DELETE)
	}
}