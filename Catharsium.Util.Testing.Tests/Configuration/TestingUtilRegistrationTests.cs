using Catharsium.Util.Testing.Configuration;
using Catharsium.Util.Testing.Extensions;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Tests.Configuration
{
    [TestClass]
    public class TestingUtilRegistrationTests
    {
        [TestMethod]
        public void AddTestingUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddTestingUtilities(config);
            serviceCollection.ReceivedRegistration<IDependencyRetriever, DependencyRetriever>();
        }
    }
}