using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccess.Models;
using DataAccess.Queries;

namespace DataAccess.Repositories
{
    public class FantasyTeamPlayerRepository
    {
        private readonly string _connectionString;

        public FantasyTeamPlayerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public (IEnumerable<FantasyTeamPlayer> Players, int TotalCount) GetFilteredAvailablePlayers(
            string searchString,
            string sortOrder,
            string positionFilter,
            int currentPage,
            int pageSize)
        {
            List<FantasyTeamPlayer> availablePlayers = [];
            int totalCount = 0;

            try
            {
                using SqlConnection connection = new(_connectionString);
                using SqlCommand command = new(FantasyTeamPlayerQueries.GetFilteredAvailablePlayers, connection);

                command.Parameters.AddWithValue("@SearchString", searchString ?? "");
                command.Parameters.AddWithValue("@SortOrder", sortOrder ?? "");
                command.Parameters.AddWithValue("@PositionFilter", positionFilter ?? "");
                command.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize);
                command.Parameters.AddWithValue("@PageSize", pageSize);

                connection.Open();
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (totalCount == 0)
                    {
                        totalCount = reader.GetInt32(reader.GetOrdinal("TotalCount"));
                    }

                    availablePlayers.Add(new FantasyTeamPlayer
                    {
                        PlayerID = reader.GetInt32(reader.GetOrdinal("PlayerID")),
                        FantasyTeamID = null,
                        PositionID = reader.GetInt32(reader.GetOrdinal("PositionID"))
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving filtered available players: {ex.Message}");
            }

            return (availablePlayers, totalCount);
        }

        public void AddPlayerToTeam(int fantasyTeamId, int playerId, FantasyTeamRepository fantasyTeamRepo)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();

                using (SqlCommand validateCommand = new(FantasyTeamPlayerQueries.ValidatePlayerAvailability, connection))
                {
                    validateCommand.Parameters.AddWithValue("@PlayerID", playerId);
                    int availableCount = (int)validateCommand.ExecuteScalar();
                    if (availableCount == 0)
                    {
                        throw new Exception("Player is not available for drafting.");
                    }
                }

                PositionRepository positionRepository = new(_connectionString);
                int positionId = positionRepository.GetPositionIdByPlayerId(playerId);

                if (positionId == 0)
                {
                    throw new Exception("Unable to determine the player's position.");
                }

                using SqlCommand command = new(FantasyTeamPlayerQueries.AddPlayerToTeam, connection);
                command.Parameters.AddWithValue("@FantasyTeamID", fantasyTeamId);
                command.Parameters.AddWithValue("@PlayerID", playerId);
                command.Parameters.AddWithValue("@PositionID", positionId);

                command.ExecuteNonQuery();
                UpdateDraftingStatus(fantasyTeamRepo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding player to fantasy team: {ex.Message}");
            }
        }

        private void UpdateDraftingStatus(FantasyTeamRepository fantasyTeamRepo)
        {
            int totalTeams = fantasyTeamRepo.GetTotalTeams();
            int currentDraftingTeamId = fantasyTeamRepo.GetCurrentDraftingTeamId();
            int nextDraftingTeamId = (currentDraftingTeamId % totalTeams) + 1;
            fantasyTeamRepo.UpdateCurrentDraftingTeam(nextDraftingTeamId);
        }


        public IEnumerable<FantasyTeamPlayer> GetAvailablePlayers()
        {
            List<FantasyTeamPlayer> availablePlayers = [];
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                using SqlCommand command = new(FantasyTeamPlayerQueries.GetAvailablePlayers, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    availablePlayers.Add(new FantasyTeamPlayer
                    {
                        PlayerID = reader.GetInt32(reader.GetOrdinal("PlayerID")),
                        FantasyTeamID = null,
                        PositionID = reader.GetInt32(reader.GetOrdinal("PositionID"))
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving available players: {ex.Message}");
            }
            return availablePlayers;
        }

        public IEnumerable<FantasyTeamPlayer> GetRosterByFantasyId(int fantasyTeamId)
        {
            List<FantasyTeamPlayer> roster = [];

            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamPlayerQueries.GetRosterByFantasyId, connection);

            command.Parameters.AddWithValue("@FantasyTeamID", fantasyTeamId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                roster.Add(new FantasyTeamPlayer
                {
                    PlayerID = reader.GetInt32(reader.GetOrdinal("PlayerID")),
                    PositionID = reader.GetInt32(reader.GetOrdinal("PositionID")),
                    FantasyTeamID = fantasyTeamId
                });
            }

            return roster;
        }

        public void RemovePlayerFromRoster(int fantasyTeamId, int playerId)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new(FantasyTeamPlayerQueries.RemovePlayerFromRoster, connection);

            command.Parameters.AddWithValue("@FantasyTeamID", fantasyTeamId);
            command.Parameters.AddWithValue("@PlayerID", playerId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}