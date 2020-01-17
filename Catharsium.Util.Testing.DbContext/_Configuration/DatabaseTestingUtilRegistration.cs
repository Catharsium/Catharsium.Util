using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Testing._Configuration;
using Catharsium.Util.Testing.Databases.Substitutes;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.Databases._Configuration
{
    public static class DatabaseTestingUtilRegistration
    {
        public static IServiceCollection AddDatabaseTestingUtilities<T>(this IServiceCollection services, IConfiguration config) where T : DbContext
        {
            var configuration = config.Load<TestingUtilConfiguration>();

            services.AddScoped<ISubstituteFactory, DbContextSubstituteFactory<T>>();

            return services;
        }
    }
}