using Catharsium.Util.Testing.Extensions;
using Catharsium.Util.Web.Configuration;
using Catharsium.Util.Web.Interfaces;
using Catharsium.Util.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Web.Tests.Configuration
{
    [TestClass]
    public class UtilWebRegistrationTests
    {
        [TestMethod]
        public void AddFileSync_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = new WebUtilConfiguration();

            serviceCollection.AddWebUtilities(config);
            serviceCollection.ReceivedRegistration<IRestService>();
            serviceCollection.ReceivedRegistration<IUrlHelper>();
        }
    }
}