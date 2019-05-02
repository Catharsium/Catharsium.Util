using Catharsium.Util.Math.Interfaces;
using Catharsium.Util.Math.Lists;
using Catharsium.Util.Math._Configuration;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Math.Tests._Configuration
{
    [TestClass]
    public class MathUtilRegistrationTests
    {
        [TestMethod]
        public void AddMathUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddMathUtilities(config);
            serviceCollection.ReceivedRegistration<IListMultiplicator, ListMultiplicator>();
        }
    }
}