using Catharsium.Util.Testing._Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Catharsium.Util.Testing.Databases._Configuration
{
    public class ServiceProviderFactory
    {
        public static IServiceProvider Create<T>(IServiceCollection serviceCollection) where T : DbContext
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            var configuration = builder.Build();

            return serviceCollection
                .AddTestingUtilities(configuration)
                .AddDatabaseTestingUtilities<T>()
                .BuildServiceProvider();
        }
    }
}