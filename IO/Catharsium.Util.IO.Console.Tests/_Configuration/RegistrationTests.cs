using Catharsium.Util.IO.Console._Configuration;
using Catharsium.Util.IO.Console.ActionHandlers.Implementation;
using Catharsium.Util.IO.Console.ActionHandlers.Interfaces;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Util.IO.Console.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddIoUtilities_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var config = Substitute.For<IConfiguration>();

        serviceCollection.AddConsoleIoUtilities(config);
        serviceCollection.ReceivedRegistration<ISingleMenuActionHandler, SingleMenuActionHandler>();
        serviceCollection.ReceivedRegistration<IMainMenuActionHandler, MainMenuActionHandler>();
        serviceCollection.ReceivedRegistration<IConsoleWrapper, SystemConsoleWrapper>();
        serviceCollection.ReceivedRegistration<IConsole, ExtendedConsole>();
    }
}