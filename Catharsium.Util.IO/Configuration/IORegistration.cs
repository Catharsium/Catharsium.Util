﻿using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Wrappers;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.IO.Configuration
{
    public static class IORegistration
    {
        public static IServiceCollection AddUtilIO(this IServiceCollection services)
        {
            services.AddTransient<IFileFactory, FileFactory>();
            return services;
        }
    }
}