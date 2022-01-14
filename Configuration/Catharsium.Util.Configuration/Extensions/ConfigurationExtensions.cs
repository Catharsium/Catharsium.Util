using Microsoft.Extensions.Configuration;
namespace Catharsium.Util.Configuration.Extensions;

public static class ConfigurationExtensions
{
    public static T Load<T>(this IConfiguration config)
    {
        var assemblyName = typeof(T).Assembly.GetName().Name;
        return config.Load<T>(assemblyName);
    }


    public static T Load<T>(this IConfiguration config, string sectionName)
    {
        return config.GetSection(sectionName).Get<T>();
    }
}