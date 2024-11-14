using Web_App.Services;

namespace Web_App.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDatabaseInitializer(this IServiceCollection services)
        {
            services.AddScoped<DatabaseInitializer>();
            return services;
        }
    }
}