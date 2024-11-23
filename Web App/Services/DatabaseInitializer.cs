using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DataAccess.Queries;

namespace Web_App.Services
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;
        private readonly string _masterConnectionString;
        private readonly ILogger<DatabaseInitializer> _logger;
        private readonly IWebHostEnvironment _environment;

        public DatabaseInitializer(IConfiguration configuration, ILogger<DatabaseInitializer> logger, IWebHostEnvironment environment)
        {
            string? baseConnection = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(baseConnection))
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            _masterConnectionString = new SqlConnectionStringBuilder(baseConnection)
            {
                InitialCatalog = "master"
            }.ConnectionString;

            _connectionString = baseConnection;
            _logger = logger;
            _environment = environment;
        }

        private IEnumerable<string> SplitSqlStatements(string script)
        {
            return Regex
                .Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase)
                .Where(batch => !string.IsNullOrWhiteSpace(batch))
                .Select(batch => batch.Trim());
        }

        private async Task EnsureDatabaseExists()
        {
            try
            {
                await using SqlConnection masterConnection = new(_masterConnectionString);
                await masterConnection.OpenAsync();

                // Check if database exists

                await using SqlCommand checkCommand = new(DBQueries.CheckDB, masterConnection);
                int dbExists = Convert.ToInt32(await checkCommand.ExecuteScalarAsync());

                if (dbExists == 0)
                {
                    _logger.LogInformation("Database 'Team13' does not exist. Creating...");

                    // Read the CreateDatabase.sql file from the correct path
                    string createDbScript = await File.ReadAllTextAsync(
                        Path.Combine(_environment.ContentRootPath, "..", "DataAccess", "Tables", "CreateDatabase.sql"));

                    foreach (string batch in SplitSqlStatements(createDbScript))
                    {
                        if (!string.IsNullOrWhiteSpace(batch))
                        {
                            await using SqlCommand command = new(batch, masterConnection);
                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    _logger.LogInformation("Database 'Team13' created successfully.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ensuring database exists");
                throw;
            }
        }

        private async Task<bool> IsDatabaseInitialized()
        {
            try
            {
                await using SqlConnection connection = new(_connectionString);
                await connection.OpenAsync();

                // First check if the Football schema exists

                await using SqlCommand schemaCommand = new(DBQueries.CheckSchema, connection);
                int schemaExists = Convert.ToInt32(await schemaCommand.ExecuteScalarAsync());

                if (schemaExists == 0)
                {
                    _logger.LogInformation("Football schema does not exist.");
                    return false;
                }

                // Then check if the Team table exists in the Football schema

                await using SqlCommand tableCommand = new(DBQueries.CheckTable, connection);
                int tableExists = Convert.ToInt32(await tableCommand.ExecuteScalarAsync());

                if (tableExists == 0)
                {
                    _logger.LogInformation("Football.Team table does not exist.");
                    return false;
                }

                // Only if both schema and table exist, check for data
                await using SqlCommand dataCommand = new(DBQueries.CheckData, connection);
                int teamCount = Convert.ToInt32(await dataCommand.ExecuteScalarAsync());

                return teamCount > 0;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error checking database initialization status");
                return false;
            }
        }

        public async Task InitializeAsync()
        {
            try
            {
                await EnsureDatabaseExists();

                if (await IsDatabaseInitialized())
                {
                    _logger.LogInformation("Database is already initialized. Skipping initialization.");
                    return;
                }

                _logger.LogInformation("Database not initialized. Starting initialization process...");

                string sqlFolderPath1 = Path.Combine(_environment.ContentRootPath, "..", "DataAccess", "Tables");
                string sqlFolderPath2 = Path.Combine(_environment.ContentRootPath, "..", "DataAccess", "Data");
                string[] sqlFiles =
                [
                    "DropTables.sql",
                    "CreateTables.sql",
                    "AddBig12Teams.sql",
                    "AddBig12Players.sql",
                    "AddGames.sql",
                    "AddSeasons.sql",
                    "AddOffenses.sql",
                    "AddDefenses.sql",
                    "AddSpecialTeams.sql",
                    "AddPositions.sql",
                    "AddFantasyTeams.sql",
                    "AddFantasyTeamPlayers.sql",
                    "AddFantasyPlayersToFantasyTeam.sql",
                    "FixGameIdBetweenStats.sql"
                ];

                await using SqlConnection connection = new(_connectionString);
                await connection.OpenAsync();

                int i = 0;

                foreach (string file in sqlFiles)
                {
                    string filePath;
                    if (i < 2)
                    {
                        filePath = Path.Combine(sqlFolderPath1, file);
                        if (!File.Exists(filePath))
                        {
                            _logger.LogWarning($"SQL file not found: {filePath}");
                            continue;
                        }
                    }
                    else
                    {
                        filePath = Path.Combine(sqlFolderPath2, file);
                        if (!File.Exists(filePath))
                        {
                            _logger.LogWarning($"SQL file not found: {filePath}");
                            continue;
                        }
                    }

                    _logger.LogInformation($"Executing SQL script: {file}");
                    string script = await File.ReadAllTextAsync(filePath);
                    foreach (string batch in SplitSqlStatements(script))
                    {
                        if (!string.IsNullOrWhiteSpace(batch))
                        {
                            await using SqlCommand command = new(batch, connection);
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                    _logger.LogInformation($"Successfully executed SQL script: {file}");
                    i++;
                }

                _logger.LogInformation("Database initialization completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error initializing database");
                throw;
            }
        }
    }
}