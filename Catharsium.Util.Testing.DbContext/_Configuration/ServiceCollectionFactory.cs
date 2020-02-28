using Catharsium.Util.Testing._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Catharsium.Util.Testing.DbContext._Configuration
{
    public class ServiceCollectionFactory
    {
        public static IServiceCollection Create(IServiceCollection serviceCollection)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            var configuration = builder.Build();

            return serviceCollection.AddTestingUtilities(configuration);
        }
    }
}