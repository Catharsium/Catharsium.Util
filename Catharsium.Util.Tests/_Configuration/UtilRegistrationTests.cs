using Catharsium.Util._Configuration;
using Catharsium.Util.Comparing.Sorting;
using Catharsium.Util.Interfaces;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Tests._Configuration
{
    [TestClass]
    public class UtilRegistrationTests
    {
        [TestMethod]
        public void AddCatharsiumUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddCatharsiumUtilities(config);
            serviceCollection.ReceivedRegistration<IEnumerableSorter<decimal>, QuickSorter<decimal>>();
        }
    }
}