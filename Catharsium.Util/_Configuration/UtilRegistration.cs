using Catharsium.Util.Comparing.Sorting;
using Catharsium.Util.Interfaces;
using Catharsium.Util.Reflection.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util._Configuration
{
    public static class UtilRegistration
    {
        public static IServiceCollection AddCatharsiumUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.GetSection("Catharsium.Util").Get<UtilConfiguration>();
            services.AddSingleton<UtilConfiguration, UtilConfiguration>(_ => configuration);

            services.AddTransient<IEnumerableSorter<decimal>, QuickSorter<decimal>>();
            services.AddSingleton<ITypesRetriever, TypesRetriever>();

            return services;
        }
    }
}