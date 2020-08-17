using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console.ActionHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.IO.Console._Configuration
{
    public static class ConsoleIoUtilRegistration
    {
        public static IServiceCollection AddConsoleIoUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<ConsoleIoUtilConfiguration>();
            services.AddSingleton<ConsoleIoUtilConfiguration, ConsoleIoUtilConfiguration>(_ => configuration);

            services.AddTransient<IChooseActionHandler, ChooseActionHandler>();
            services.AddTransient<IConsoleWrapper, SystemConsoleWrapper>();
            services.AddTransient<IConsole, ExtendedConsole>();

            return services;
        }
    }
}