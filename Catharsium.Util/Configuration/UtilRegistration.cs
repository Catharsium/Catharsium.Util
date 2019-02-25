using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Configuration
{
    public static class UtilRegistration
    {
        public static IServiceCollection AddCatharsiumUtilities(this IServiceCollection services, UtilConfiguration config)
        {
            return services;
        }
    }
}