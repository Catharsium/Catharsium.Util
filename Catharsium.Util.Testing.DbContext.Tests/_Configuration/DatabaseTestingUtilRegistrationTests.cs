using Catharsium.Util.Testing.Databases._Configuration;
using Catharsium.Util.Testing.Databases.Substitutes;
using Catharsium.Util.Testing.Databases.Tests.Mocks;
using Catharsium.Util.Testing.Extensions;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Testing.Databases.Tests._Configuration
{
    [TestClass]
    public class DatabaseTestingUtilRegistrationTests
    {
        [TestMethod]
        public void AddTestingUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();

            serviceCollection.AddDatabaseTestingUtilities<MockDbContextWithTypedOptions>();
            serviceCollection.ReceivedRegistration<ISubstituteFactory, DbContextSubstituteFactory<MockDbContextWithTypedOptions>>();
        }
    }
}