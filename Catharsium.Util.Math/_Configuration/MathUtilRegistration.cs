using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Math.Interfaces;
using Catharsium.Util.Math.Lists;
using Catharsium.Util.Math.Numbers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Math._Configuration
{
    public static class MathUtilRegistration
    {
        public static IServiceCollection AddMathUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<MathUtilConfiguration>();

            services.AddScoped<IListMultiplicator, ListMultiplicator>();
            services.AddScoped<IRounder, NearestRounder>();

            return services;
        }
    }
}