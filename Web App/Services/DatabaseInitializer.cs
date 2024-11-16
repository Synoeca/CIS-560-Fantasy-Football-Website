using System.Data.SqlClient;
using System.Text.RegularExpressions;

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
                const string checkDbQuery = """
                                            
                                                        SELECT COUNT(*) 
                                                        FROM sys.databases 
                                                        WHERE name = 'Team13'
                                            """;

                await using SqlCommand checkCommand = new(checkDbQuery, masterConnection);
                int dbExists = Convert.ToInt32(await checkCommand.ExecuteScalarAsync());

                if (dbExists == 0)
                {
                    _logger.LogInformation("Database 'Team13' does not exist. Creating...");

                    // Read the CreateDatabase.sql file from the correct path
                    string createDbScript = await File.ReadAllTextAsync(
                        Path.Combine(_environment.ContentRootPath, "..", "DataAccess", "SQL", "sqls", "CreateDatabase.sql"));

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

                const string checkDataQuery = "SELECT COUNT(*) FROM Football.Team";
                await using SqlCommand dataCommand = new(checkDataQuery, connection);
                int teamCount = Convert.ToInt32(await dataCommand.ExecuteScalarAsync());

                return teamCount > 0;
            }
            catch (Exception)
            {
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

                string sqlFolderPath = Path.Combine(_environment.ContentRootPath, "..", "DataAccess", "SQL", "sqls");
                string[] sqlFiles =
                [
                    "DropTables.sql",
                    "CreateTables.sql",
                    "AddBig12Teams.sql",
                    "AddBig12Players.sql",
                    "AddPositions.sql",
                    "AddFantasyTeams.sql",
                    "AddFantasyTeamPlayer.sql",
                    "AddGames.sql",
                    "AddOffenseData.sql",
                    "AddDefenseData.sql",
                    "AddSpecialTeamsData.sql",
                    "AddSeasons.sql"
                ];

                await using SqlConnection connection = new(_connectionString);
                await connection.OpenAsync();

                foreach (string file in sqlFiles)
                {
                    string filePath = Path.Combine(sqlFolderPath, file);
                    if (!File.Exists(filePath))
                    {
                        _logger.LogWarning($"SQL file not found: {filePath}");
                        continue;
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