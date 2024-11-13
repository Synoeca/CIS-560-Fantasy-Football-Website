using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories;

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
                    SchoolName = Convert.ToString(reader["SchoolName"]) ?? string.Empty,
                    GameID = Convert.ToInt32(reader["GameID"]),
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
}