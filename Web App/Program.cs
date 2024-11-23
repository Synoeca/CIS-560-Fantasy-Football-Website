using DataAccess.Repositories;
using Web_App.Extensions;
using Web_App.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDatabaseInitializer();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddScoped<PlayerRepository>(_ => new PlayerRepository(connectionString));
builder.Services.AddScoped<FantasyTeamRepository>(_ => new FantasyTeamRepository(connectionString));
builder.Services.AddScoped<PositionRepository>(_ => new PositionRepository(connectionString));

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    try
    {
        DatabaseInitializer initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
        await initializer.InitializeAsync();
        Console.WriteLine("Database initialized successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();