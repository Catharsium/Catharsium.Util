using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace Catharsium.Util.Configuration.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterAll<T>(this IServiceCollection services, ServiceLifetime lifetime, params Assembly[] assemblies)
    {
        var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(t => t.GetInterfaces().Contains(typeof(T))));
        foreach (var type in typesFromAssemblies) {
            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }

        return services;
    }


    public static IServiceCollection RegisterAll<T>(this IServiceCollection services, params Assembly[] assemblies)
    {
        return services.RegisterAll<T>(ServiceLifetime.Transient, assemblies);
    }


    public static IServiceCollection RegisterTypes(this IServiceCollection services, Dictionary<string, string> types, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        foreach (var type in types) {
            services.Add(new ServiceDescriptor(Type.GetType(type.Value), Type.GetType(type.Key), lifetime));
        }

        return services;
    }


    public static IServiceCollection RegisterTypes<T>(this IServiceCollection services, IEnumerable<string> types, ServiceLifetime lifetime = ServiceLifetime.Transient)
    {
        foreach (var type in types) {
            services.Add(new ServiceDescriptor(typeof(T), Type.GetType(type), lifetime));
        }

        return services;
    }
}