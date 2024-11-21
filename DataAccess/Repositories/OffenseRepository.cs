using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories;

public class OffenseRepository
{
    private readonly string _connectionString;

    public OffenseRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Offense>? GetOffenseStatsByPlayerId(int playerId)
    {
        List<Offense>? offenseStats = [];
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(OffenseQueries.GetOffenseStatsByPlayerId, connection);
            command.Parameters.AddWithValue("@PlayerID", playerId);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                offenseStats.Add(new Offense
                {
                    PlayerID = Convert.ToInt32(reader["PlayerID"]),
                    GameID = Convert.ToInt32(reader["GameID"]),
                    PassingYards = reader["PassingYards"] is DBNull ? 0f : Convert.ToSingle(reader["PassingYards"]),
                    PassingAttempts = Convert.ToInt32(reader["PassingAttempts"]),
                    RushingYards = reader["RushingYards"] is DBNull ? 0f : Convert.ToSingle(reader["RushingYards"]),
                    Carries = Convert.ToInt32(reader["Carries"]),
                    ReceivingYards = reader["ReceivingYards"] is DBNull ? 0f : Convert.ToSingle(reader["ReceivingYards"]),
                    Receptions = Convert.ToInt32(reader["Receptions"]),
                    Touchdowns = Convert.ToInt32(reader["Touchdowns"])
                });
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Repository error: {ex.Message}");
        }
        return offenseStats;
    }

    public void InsertOffense(Offense offense)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            using SqlCommand checkCommand = new(OffenseQueries.GetOffenseByPlayerAndGame, connection);
            checkCommand.Parameters.AddWithValue("@PlayerID", offense.PlayerID);
            checkCommand.Parameters.AddWithValue("@GameID", offense.GameID);

            using SqlDataReader reader = checkCommand.ExecuteReader();
            if (reader.HasRows)
            {
                throw new Exception("Stats already exist for this player in this game.");
            }
            reader.Close();

            using SqlCommand command = new(OffenseQueries.InsertOffense, connection);
            command.Parameters.AddWithValue("@PlayerID", offense.PlayerID);
            command.Parameters.AddWithValue("@GameID", offense.GameID);
            command.Parameters.AddWithValue("@PassingYards", offense.PassingYards);
            command.Parameters.AddWithValue("@PassingAttempts", offense.PassingAttempts);
            command.Parameters.AddWithValue("@RushingYards", offense.RushingYards);
            command.Parameters.AddWithValue("@Carries", offense.Carries);
            command.Parameters.AddWithValue("@ReceivingYards", offense.ReceivingYards);
            command.Parameters.AddWithValue("@Receptions", offense.Receptions);
            command.Parameters.AddWithValue("@Touchdowns", offense.Touchdowns);

            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error inserting offense stats: {ex.Message}");
        }
    }

    public Offense GetOffenseByPlayerAndGame(int playerId, int gameId)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(OffenseQueries.GetOffenseByPlayerAndGame, connection);
            command.Parameters.AddWithValue("@PlayerID", playerId);
            command.Parameters.AddWithValue("@GameID", gameId);
            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Offense
                {
                    PlayerID = Convert.ToInt32(reader["PlayerID"]),
                    GameID = Convert.ToInt32(reader["GameID"]),
                    PassingYards = Convert.ToSingle(reader["PassingYards"]),
                    PassingAttempts = Convert.ToInt32(reader["PassingAttempts"]),
                    RushingYards = Convert.ToSingle(reader["RushingYards"]),
                    Carries = Convert.ToInt32(reader["Carries"]),
                    ReceivingYards = Convert.ToSingle(reader["ReceivingYards"]),
                    Receptions = Convert.ToInt32(reader["Receptions"]),
                    Touchdowns = Convert.ToInt32(reader["Touchdowns"])
                };
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving offense stats: {ex.Message}");
        }
    }

    public void UpdateOffense(Offense offense)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(OffenseQueries.UpdateOffense, connection);

            command.Parameters.AddWithValue("@PlayerID", offense.PlayerID);
            command.Parameters.AddWithValue("@GameID", offense.GameID);
            command.Parameters.AddWithValue("@PassingYards", offense.PassingYards);
            command.Parameters.AddWithValue("@PassingAttempts", offense.PassingAttempts);
            command.Parameters.AddWithValue("@RushingYards", offense.RushingYards);
            command.Parameters.AddWithValue("@Carries", offense.Carries);
            command.Parameters.AddWithValue("@ReceivingYards", offense.ReceivingYards);
            command.Parameters.AddWithValue("@Receptions", offense.Receptions);
            command.Parameters.AddWithValue("@Touchdowns", offense.Touchdowns);

            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating offense stats: {ex.Message}");
        }
    }

    public void DeleteOffense(int playerId, int gameId)
    {
        try
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            using SqlCommand command = new(OffenseQueries.DeleteOffense, connection);
            command.Parameters.AddWithValue("@PlayerID", playerId);
            command.Parameters.AddWithValue("@GameID", gameId);
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting offense stats: {ex.Message}");
        }
    }
}