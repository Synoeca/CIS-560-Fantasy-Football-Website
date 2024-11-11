var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Simplified connection string
var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CIS560;Integrated Security=True";

// Register repositories with the connection string
builder.Services.AddScoped<PlayerRepository>(_ => new PlayerRepository(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
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