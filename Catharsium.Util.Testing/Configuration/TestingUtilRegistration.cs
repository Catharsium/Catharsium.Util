using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Substitutes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.Configuration
{
    public static class TestingUtilRegistration
    {
        public static IServiceCollection AddTestingUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<TestingUtilConfiguration>();

            services.AddScoped<IDependencyRetriever, DependencyRetriever>();
            services.AddScoped<ISubstituteFactory, SubstituteFactory>();

            return services;
        }
    }
}