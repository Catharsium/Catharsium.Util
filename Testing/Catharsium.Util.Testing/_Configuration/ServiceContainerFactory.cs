using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing._Configuration;

public class ServiceProviderFactory
{
    public static IServiceProvider Create(IServiceCollection serviceCollection) {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
        var configuration = builder.Build();

        return serviceCollection
            .AddTestingUtilities(configuration)
            .BuildServiceProvider();
    }
}