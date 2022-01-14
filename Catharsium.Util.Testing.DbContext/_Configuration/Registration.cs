using Catharsium.Util.Testing.DbContext.Substitutes;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.DbContext._Configuration
{
    public static class Registration
    {
        public static IServiceCollection AddDatabaseTestingUtilities<T>(this IServiceCollection services) where T : Microsoft.EntityFrameworkCore.DbContext
        {
            services.AddScoped<ISubstituteFactory, DbContextSubstituteFactory<T>>();
            services.AddScoped(p => typeof(T));
            return services;
        }
    }
}