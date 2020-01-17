using Catharsium.Util.Testing.Databases.Substitutes;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.Databases._Configuration
{
    public static class DatabaseTestingUtilRegistration
    {
        public static IServiceCollection AddDatabaseTestingUtilities<T>(this IServiceCollection services) where T : DbContext
        {
            services.AddScoped<ISubstituteFactory, DbContextSubstituteFactory<T>>();
            services.AddScoped(p => typeof(T));
            return services;
        }
    }
}