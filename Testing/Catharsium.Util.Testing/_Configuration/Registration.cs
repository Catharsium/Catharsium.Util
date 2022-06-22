using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Reflection;
using Catharsium.Util.Testing.Substitutes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Catharsium.Util.Testing._Configuration;

public static class Registration
{
    public static IServiceCollection AddTestingUtilities(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<TestingUtilConfiguration>();
        services.AddSingleton<TestingUtilConfiguration, TestingUtilConfiguration>(_ => configuration);

        services.TryAddScoped<IDependencyRetriever, DependencyRetriever>();
        services.TryAddScoped<IConstructorFilter, ConstructorFilter>();
        services.TryAddScoped<ISubstituteService, SubstituteService>();

        services.AddScoped<ISubstituteFactory, GuidSubstituteFactory>();
        services.AddScoped<ISubstituteFactory, InterfaceSubstituteFactory>();
        services.AddScoped(p => typeof(Guid));

        return services;
    }
}