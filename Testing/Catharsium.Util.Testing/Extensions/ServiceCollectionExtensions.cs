using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Catharsium.Util.Testing.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ReceivedRegistration<TInterface>(this IServiceCollection serviceCollection) {
        serviceCollection.Received().Add(Arg.Is<ServiceDescriptor>(d => d.ServiceType == typeof(TInterface)));
        return serviceCollection;
    }


    public static IServiceCollection ReceivedRegistration<TInterface, TImplementation>(this IServiceCollection serviceCollection) {
        serviceCollection.Received().Add(Arg.Is<ServiceDescriptor>(d =>
            d.ServiceType == typeof(TInterface) &&
            d.ImplementationType == typeof(TImplementation)
        ));
        return serviceCollection;
    }
}