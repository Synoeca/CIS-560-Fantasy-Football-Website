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
                    Seasons season = new(
                        Convert.ToInt32(reader["SeasonID"]),
                        reader["GameID"] is DBNull ? null : Convert.ToInt32(reader["GameID"]),
                        reader["TeamID"] is DBNull ? null : Convert.ToInt32(reader["TeamID"]),
                        reader["Year"] is DBNull ? null : Convert.ToInt32(reader["Year"]),
                        reader["Wins"] is DBNull ? null : Convert.ToInt32(reader["Wins"]),
                        reader["Loses"] is DBNull ? null : Convert.ToInt32(reader["Loses"])
                    );
                    seasons.Add(season);
                }
                return seasons;
            }
            catch
            {
                return Enumerable.Empty<Seasons>();
            }
        }

        public Seasons? GetSeasonById(int seasonId)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(SeasonsQueries.GetSeasonById, connection);
                command.Parameters.AddWithValue("@SeasonID", seasonId);
                using SqlDataReader? reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Seasons(
                        Convert.ToInt32(reader["SeasonID"]),
                        reader["GameID"] is DBNull ? null : Convert.ToInt32(reader["GameID"]),
                        reader["TeamID"] is DBNull ? null : Convert.ToInt32(reader["TeamID"]),
                        reader["Year"] is DBNull ? null : Convert.ToInt32(reader["Year"]),
                        reader["Wins"] is DBNull ? null : Convert.ToInt32(reader["Wins"]),
                        reader["Loses"] is DBNull ? null : Convert.ToInt32(reader["Loses"])
                    );
                }
                return null;
            }
            catch
            {
                return null;
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
                    SeasonPerformance performance = new(
                        Convert.ToInt32(reader["Season"]),
                        reader["SchoolName"].ToString() ?? string.Empty,
                        Convert.ToInt32(reader["Wins"]),
                        Convert.ToInt32(reader["Losses"]),
                        Convert.ToDecimal(reader["WinningPercentage"])
                    );
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