using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.IO.Files.Csv;
using Catharsium.Util.IO.Files.Interfaces;
using Catharsium.Util.IO.Files.Json;
using Catharsium.Util.IO.Files.Wrappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace Catharsium.Util.IO.Files._Configuration;

public static class Registration
{
    public static IServiceCollection AddFilesIoUtilities(this IServiceCollection services, IConfiguration config)
    {
        var configuration = config.Load<IoUtilConfiguration>();
        services.AddSingleton<IoUtilConfiguration, IoUtilConfiguration>(_ => configuration);

        services.TryAddTransient<IFileFactory, FileFactory>();
        services.TryAddTransient<IJsonFileReader, JsonFileReader>();
        services.TryAddTransient<IJsonFileWriter, JsonFileWriter>();

        services.TryAddTransient<ICsvReader, CsvReader>();

        return services;
    }
}