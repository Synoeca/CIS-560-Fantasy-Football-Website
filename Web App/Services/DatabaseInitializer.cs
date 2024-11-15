using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Web_App.Services
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;
        private readonly ILogger<DatabaseInitializer> _logger;
        private readonly IWebHostEnvironment _environment;

        public DatabaseInitializer(IConfiguration configuration, ILogger<DatabaseInitializer> logger, IWebHostEnvironment environment)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
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

        public async Task InitializeAsync()
        {
            try
            {
                string sqlFolderPath = Path.Combine(_environment.ContentRootPath, "..", "DataAccess", "SQL", "sqls");

                string[] sqlFiles =
                [
                    "DropTables.sql",
                    "CreateTables.sql",
                    "AddBig12Teams.sql",
                    "AddBig12Players.sql",
                    "AddGames.sql",
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