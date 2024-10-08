﻿using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Menu.Implementation;
using Catharsium.Util.IO.Console.Menu.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Catharsium.Util.IO.Console._Configuration;

public static class Registration
{
    public static IServiceCollection AddConsoleIoUtilities(this IServiceCollection services, IConfiguration config) {
        var configuration = config.Load<ConsoleIoUtilSettings>();
        services.AddSingleton<ConsoleIoUtilSettings, ConsoleIoUtilSettings>(_ => configuration);

        services.TryAddScoped<ISingleMenuActionHandler, SingleMenuActionHandler>();
        services.TryAddScoped<IMainMenuActionHandler, MainMenuActionHandler>();
        services.TryAddScoped<IConsoleWrapper, SystemConsoleWrapper>();
        services.TryAddScoped<IConsole, ExtendedConsole>();

        return services;
    }
}