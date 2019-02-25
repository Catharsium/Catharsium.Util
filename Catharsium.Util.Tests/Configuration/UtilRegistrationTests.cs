using Catharsium.Util.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests.Configuration
{
    [TestClass]
    public class UtilRegistrationTests
    {
        [TestMethod]
        public void AddFileSync_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = new UtilConfiguration();

            serviceCollection.AddCatharsiumUtilities(config);
        }
    }
}