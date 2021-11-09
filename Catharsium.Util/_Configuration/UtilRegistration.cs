using Catharsium.Util.Comparing;
using Catharsium.Util.Comparing.Sorting;
using Catharsium.Util.Interfaces;
using Catharsium.Util.Reflection.Types;
using Catharsium.Util.Time.Format;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace Catharsium.Util._Configuration
{
    public static class UtilRegistration
    {
        public static IServiceCollection AddCatharsiumUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.GetSection("Catharsium.Util").Get<UtilConfiguration>();
            services.AddSingleton<UtilConfiguration, UtilConfiguration>(_ => configuration);

            services.TryAddScoped<IComparer<decimal>, DecimalComparer>();
            services.TryAddScoped<IComparer<int>, IntComparer>();
            services.TryAddScoped<IComparer<string>, StringLengthComparer>();

            services.TryAddScoped<IEnumerableSorter<decimal>, QuickSorter<decimal>>();
            services.TryAddTransient<ITypesRetriever, TypesRetriever>();

            services.TryAddScoped<ITimeFormatParser, TimeFormatParser>();

            return services;
        }
    }
}