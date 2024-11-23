using DataAccess.Models;
using FootballData.Sql.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SeasonsRepository
    {
        private readonly string _connectionString;

        public SeasonsRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string is empty");
            }
            _connectionString = connectionString;
        }

        public IEnumerable<Seasons> GetAllSeasons()
        {
            List<Seasons> seasons = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(SeasonsQueries.GetAllSeasons, connection);
                using SqlDataReader? reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Seasons season = new()
                    {
                        SeasonID = Convert.ToInt32(reader["SeasonID"]),
                        GameID = reader["GameID"] is DBNull ? null : Convert.ToInt32(reader["GameID"]),
                        TeamID = reader["TeamID"] is DBNull ? null : Convert.ToInt32(reader["TeamID"]),
                        Year = reader["Year"] is DBNull ? null : Convert.ToInt32(reader["Year"]),
                        Wins = reader["Wins"] is DBNull ? null : Convert.ToInt32(reader["Wins"]),
                        Loses = reader["Loses"] is DBNull ? null : Convert.ToInt32(reader["Loses"])
                    };
                    seasons.Add(season);
                }
                return seasons;
            }
            catch
            {
                return Enumerable.Empty<Seasons>();
            }
        }

        public IEnumerable<SeasonPerformance> GetSeasonPerformance(int year)
        {
            List<SeasonPerformance> performances = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                //const string query = AggregatingQueries.GetTeamPerformanceBySeason;

                using SqlCommand command = new(AggregatingQueries.GetTeamPerformanceBySeason, connection);
                command.Parameters.AddWithValue("@Year", year);
                using SqlDataReader? reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SeasonPerformance performance = new()
                    {
                        Season = Convert.ToInt32(reader["Season"]),
                        SchoolName = reader["SchoolName"].ToString() ?? string.Empty,
                        Wins = Convert.ToInt32(reader["Wins"]),
                        Losses = Convert.ToInt32(reader["Losses"]),
                        WinningPercentage = Convert.ToDecimal(reader["WinningPercentage"])
                    };
                    performances.Add(performance);
                }
                return performances;
            }
            catch
            {
                return Enumerable.Empty<SeasonPerformance>();
            }
        }


    }
}