using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Catharsium.Util.Testing.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void WasRegistered<I>(this IServiceCollection serviceCollection)
        {
            serviceCollection.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(I)));
        }


        public static void WasRegistered<I, T>(this IServiceCollection serviceCollection)
        {
            serviceCollection.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(I) && d.ImplementationType == typeof(T)));
        }
    }
}