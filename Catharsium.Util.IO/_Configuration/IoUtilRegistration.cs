using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console;
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

            services.AddTransient<IFileFactory, FileFactory>();
            services.AddTransient<IJsonTextWriter, JsonTextWriterAdapter>();

            services.AddTransient<IConsoleWrapper, SystemConsoleWrapper>();
            services.AddTransient<IConsole, ExtendedConsole>();

            return services;
        }
    }
}