using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Csv;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Json;
using Catharsium.Util.IO.Wrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.IO._Configuration
{
    public static class IoUtilRegistration
    {
        public static IServiceCollection AddIoUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<IoUtilConfiguration>();
            services.AddSingleton<IoUtilConfiguration, IoUtilConfiguration>(_ => configuration);

            services.AddTransient<IFileFactory, FileFactory>();
            services.AddTransient<IJsonFileReader, JsonFileReader>();
            services.AddTransient<IJsonFileWriter, JsonFileWriter>();

            services.AddTransient<ICsvReader, CsvReader>();
            //services.AddTransient<ICsvFileWriter, CsvFileWriter>();
            //services.AddTransient<ICsvWriterFactory, CsvWriterFactory>();

            return services;
        }
    }
}