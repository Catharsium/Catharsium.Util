using Catharsium.Util.Testing.DbContext._Configuration;
using Catharsium.Util.Testing.DbContext.Substitutes;
using Catharsium.Util.Testing.DbContext.Tests.Mocks;
using Catharsium.Util.Testing.Extensions;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Util.Testing.DbContext.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddTestingUtilities_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();

        serviceCollection.AddDatabaseTestingUtilities<MockDbContextWithTypedOptions>();
        serviceCollection.ReceivedRegistration<ISubstituteFactory, DbContextSubstituteFactory<MockDbContextWithTypedOptions>>();
    }
}