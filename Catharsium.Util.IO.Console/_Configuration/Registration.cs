using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console.ActionHandlers;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Catharsium.Util.IO.Console._Configuration
{
    public static class Registration
    {
        public static IServiceCollection AddConsoleIoUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<ConsoleIoUtilConfiguration>();
            services.AddSingleton<ConsoleIoUtilConfiguration, ConsoleIoUtilConfiguration>(_ => configuration);

            services.TryAddScoped<IActionHandlerRetriever, ActionHandlerRetriever>();
            services.TryAddScoped<IChooseActionHandler, ChooseActionHandler>();

            services.TryAddScoped<IConsoleWrapper, SystemConsoleWrapper>();
            services.TryAddScoped<IConsole, ExtendedConsole>();

            return services;
        }
    }
}