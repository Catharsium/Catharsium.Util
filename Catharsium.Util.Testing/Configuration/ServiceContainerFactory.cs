﻿using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Testing.Configuration
{
    public class ServiceProviderFactory
    {
        public static IServiceProvider Create()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", false, false);
            var configuration = builder.Build();

            return new ServiceCollection()
                .AddTestingUtilities(configuration)
                .BuildServiceProvider();
        }
    }
}