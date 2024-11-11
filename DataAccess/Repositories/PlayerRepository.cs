using DataAccess.Models;
using System.Data.SqlClient;

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
        var players = new List<Player>();
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var commandText = "SELECT * FROM dbo.Player";
                using var command = new SqlCommand(commandText, connection);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var player = new Player
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
        }
        catch (Exception ex)
        {
            throw new Exception($"Repository error: {ex.Message}\nConnection string: {_connectionString}");
        }

        return players;
    }
}