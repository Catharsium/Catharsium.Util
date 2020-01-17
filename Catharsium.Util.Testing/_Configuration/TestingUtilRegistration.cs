using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Testing.Interfaces;
using Catharsium.Util.Testing.Reflection;
using Catharsium.Util.Testing.Substitutes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Catharsium.Util.Testing._Configuration
{
    public static class TestingUtilRegistration
    {
        public static IServiceCollection AddTestingUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<TestingUtilConfiguration>();

            services.AddScoped<IDependencyRetriever, DependencyRetriever>();
            services.AddScoped<IConstructorFilter>(s => new ConstructorFilter(SupportedDependencies.Types));
            services.AddScoped<ISubstituteService, SubstituteService>();
            services.AddScoped<ISubstituteFactory, GuidSubstituteFactory>();
            services.AddScoped<ISubstituteFactory, InterfaceSubstituteFactory>();

            services.AddScoped(p => typeof(Guid));

            return services;
        }
    }
}