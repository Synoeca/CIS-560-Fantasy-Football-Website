using DataAccess.Models;
using DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GameRepository
    {
        private readonly string _connectionString;

        public GameRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string is empty");
            }
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

        public IEnumerable<Game> GetAllGames()
        {
            List<Game> games = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(GameQueries.GetAllGames, connection);
                using SqlDataReader? reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Game game = new()
                    {
                        GameID = Convert.ToInt32(reader["GameID"]),
                        HomeTeam = reader["HomeTeam"] is DBNull ? string.Empty : Convert.ToString(reader["HomeTeam"]),
                        AwayTeam = reader["AwayTeam"] is DBNull ? string.Empty : Convert.ToString(reader["AwayTeam"]),
                        Date = reader["GameDate"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["GameDate"]),
                        HomeTeamScore = reader["HomeTeamScore"] is DBNull ? 0 : Convert.ToInt32(reader["HomeTeamScore"]),
                        AwayTeamScore = reader["AwayTeamScore"] is DBNull ? 0 : Convert.ToInt32(reader["AwayTeamScore"])
                    };
                    games.Add(game);
                }
                return games;
            }
            catch
            {
                return Enumerable.Empty<Game>();
            }
        }
    }
}
