using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.Configuration
{
    public static class TestingUtilRegistration
    {
        public static IServiceCollection AddTestingUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<TestingUtilConfiguration>();

            return services;
        }
    }
}