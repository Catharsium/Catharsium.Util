using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Configuration.Tests.Extensions._Fixture;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Configuration.Tests.Extensions
{
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        [TestMethod]
        public void RegisterAll_FindsTypesThatImplementBase_RegistersTypes()
        {
            var services = Substitute.For<IServiceCollection>();
            var lifetime = ServiceLifetime.Scoped;

            services.RegisterAll<IMockInterface>(lifetime, typeof(MockObject).Assembly);
            services.Received().Add(Arg.Is<ServiceDescriptor>(s => s.ServiceType == typeof(IMockInterface) && s.ImplementationType == typeof(MockObject) && s.Lifetime == lifetime));
        }
    }
}