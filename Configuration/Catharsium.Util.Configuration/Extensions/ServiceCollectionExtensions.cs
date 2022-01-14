using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catharsium.Util.Configuration.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterAll<T>(this IServiceCollection services, ServiceLifetime lifetime, params Assembly[] assemblies)
    {
        var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(t => t.GetInterfaces().Contains(typeof(T))));
        foreach (var type in typesFromAssemblies) {
            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }
    }


    public static void RegisterAll<T>(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.RegisterAll<T>(ServiceLifetime.Transient, assemblies);
    }
}