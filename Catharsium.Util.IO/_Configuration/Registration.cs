using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Csv;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Json;
using Catharsium.Util.IO.Wrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Catharsium.Util.IO._Configuration
{
    public static class Registration
    {
        public static IServiceCollection AddIoUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<IoUtilConfiguration>();
            services.AddSingleton<IoUtilConfiguration, IoUtilConfiguration>(_ => configuration);

            services.TryAddTransient<IFileFactory, FileFactory>();
            services.TryAddTransient<IJsonFileReader, JsonFileReader>();
            services.TryAddTransient<IJsonFileWriter, JsonFileWriter>();

            services.TryAddTransient<ICsvReader, CsvReader>();
            //services.TryAddTransient<ICsvFileWriter, CsvFileWriter>();
            //services.TryAddTransient<ICsvWriterFactory, CsvWriterFactory>();

            return services;
        }
    }
}