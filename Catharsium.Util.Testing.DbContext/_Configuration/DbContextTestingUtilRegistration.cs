using Catharsium.Util.Testing.DbContext.Substitutes;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Catharsium.Util.Testing.DbContext._Configuration
{
    public static class DbContextTestingUtilRegistration
    {
        public static IServiceCollection AddDatabaseTestingUtilities<T>(this IServiceCollection services) where T : Microsoft.EntityFrameworkCore.DbContext
        {
            services.TryAddScoped<ISubstituteFactory, DbContextSubstituteFactory<T>>();
            services.TryAddScoped(p => typeof(T));
            return services;
        }
    }
}