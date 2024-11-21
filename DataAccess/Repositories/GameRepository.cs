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
                    Game game = new(
                        Convert.ToInt32(reader["GameID"]),
                        reader["HomeTeam"] is DBNull ? 0 : Convert.ToInt32(reader["HomeTeam"]),
                        reader["AwayTeam"] is DBNull ? 0 : Convert.ToInt32(reader["AwayTeam"]),
                        reader["Date"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["Date"]),
                        reader["Week"] is DBNull ? 0 : Convert.ToInt32(reader["Week"]),
                        reader["HomeTeamScore"] is DBNull ? 0 : Convert.ToInt32(reader["HomeTeamScore"]),
                        reader["AwayTeamScore"] is DBNull ? 0 : Convert.ToInt32(reader["AwayTeamScore"])
                    );
                    games.Add(game);
                }
                return games;
            }
            catch
            {
                return Enumerable.Empty<Game>();
            }
        }

        public int InsertGame(Game game)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(GameQueries.InsertGame, connection);

                command.Parameters.AddWithValue("@HomeTeam", game.HomeTeam);
                command.Parameters.AddWithValue("@AwayTeam", game.AwayTeam);
                command.Parameters.AddWithValue("@Date", game.Date);
                command.Parameters.AddWithValue("@Week", game.Week);
                command.Parameters.AddWithValue("@HomeTeamScore", game.HomeTeamScore);
                command.Parameters.AddWithValue("@AwayTeamScore", game.AwayTeamScore);

                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting game: {ex.Message}");
            }
        }


        public bool UpdateGame(Game game)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(GameQueries.UpdateGame, connection);

                command.Parameters.AddWithValue("@GameID", game.GameID);
                command.Parameters.AddWithValue("@HomeTeam", game.HomeTeam);
                command.Parameters.AddWithValue("@AwayTeam", game.AwayTeam);
                command.Parameters.AddWithValue("@Date", game.Date);
                command.Parameters.AddWithValue("@Week", game.Week);
                command.Parameters.AddWithValue("@HomeTeamScore", game.HomeTeamScore);
                command.Parameters.AddWithValue("@AwayTeamScore", game.AwayTeamScore);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating game: {ex.Message}");
            }
        }

        public bool DeleteGame(int gameId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(GameQueries.DeleteGame, connection);

                command.Parameters.AddWithValue("@GameID", gameId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting game: {ex.Message}");
            }
        }

        public Game? GetGameById(int gameId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(GameQueries.GetGameById, connection);

                command.Parameters.AddWithValue("@GameID", gameId);

                using SqlDataReader? reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Game
                    (
                        Convert.ToInt32(reader["GameID"]),
                        reader["HomeTeam"] is DBNull ? 0 : Convert.ToInt32(reader["HomeTeam"]),
                        reader["AwayTeam"] is DBNull ? 0 : Convert.ToInt32(reader["AwayTeam"]),
                        reader["Date"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(reader["Date"]),
                        reader["Week"] is DBNull ? 0 : Convert.ToInt32(reader["Week"]),
                        reader["HomeTeamScore"] is DBNull ? 0 : Convert.ToInt32(reader["HomeTeamScore"]),
                        reader["AwayTeamScore"] is DBNull ? 0 : Convert.ToInt32(reader["AwayTeamScore"])
                    );
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving game: {ex.Message}");
            }
        }
    }
}
