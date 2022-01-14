using Catharsium.Util.Testing.Extensions;
using Catharsium.Util.Web.Interfaces;
using Catharsium.Util.Web._Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Web.Tests._Configuration
{
    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void AddWebUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddWebUtilities(config);
            serviceCollection.ReceivedRegistration<IRestService>();
            serviceCollection.ReceivedRegistration<IUrlHelper>();
        }
    }
}