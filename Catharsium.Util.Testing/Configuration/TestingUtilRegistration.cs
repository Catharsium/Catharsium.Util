using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.Configuration
{
    public static class TestingUtilRegistration
    {
        public static IServiceCollection AddTestingUtilities(this IServiceCollection services, TestingUtilConfiguration config)
        {
            return services;
        }
    }
}