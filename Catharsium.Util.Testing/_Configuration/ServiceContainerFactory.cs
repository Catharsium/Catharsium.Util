using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing._Configuration
{
    public class ServiceProviderFactory
    {
        public static IServiceProvider Create()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            var configuration = builder.Build();

            return new ServiceCollection()
                .AddTestingUtilities(configuration)
                .BuildServiceProvider();
        }
    }
}