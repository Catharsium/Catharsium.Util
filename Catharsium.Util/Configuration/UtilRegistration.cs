using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Configuration
{
    public static class UtilRegistration
    {
        public static IServiceCollection AddCatharsiumUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.GetSection("Catharsium.Util").Get<UtilConfiguration>();

            return services;
        }
    }
}