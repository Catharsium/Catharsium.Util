using Catharsium.Util.Comparing;
using Catharsium.Util.Comparing.Sorting;
using Catharsium.Util.Interfaces;
using Catharsium.Util.Reflection.Types;
using Catharsium.Util.Time.Format;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Catharsium.Util._Configuration
{
    public static class UtilRegistration
    {
        public static IServiceCollection AddCatharsiumUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.GetSection("Catharsium.Util").Get<UtilConfiguration>();
            services.AddSingleton<UtilConfiguration, UtilConfiguration>(_ => configuration);

            services.AddScoped<IComparer<decimal>, DecimalComparer>();
            services.AddScoped<IComparer<int>, IntComparer>();
            services.AddScoped<IComparer<string>, StringLengthComparer>();

            services.AddScoped<IEnumerableSorter<decimal>, QuickSorter<decimal>>();
            services.AddTransient<ITypesRetriever, TypesRetriever>();

            services.AddScoped<ITimeFormatParser, TimeFormatParser>();

            return services;
        }
    }
}