using Catharsium.Util.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Configuration.Tests.Extensions
{
    [TestClass]
    public class ConfigurationExtensionsTests
    {
        [TestMethod]
        public void Load_WithoutSectionName_CallsGetSectionWithAssemblyName_ReturnsResult()
        {
            var configurationSection = Substitute.For<IConfigurationSection>();
            var expected = "Expected";
            configurationSection.Get<string>().Returns(expected);
            var config = Substitute.For<IConfiguration>();
            config.GetSection(typeof(string).Assembly.GetName().Name).Returns(configurationSection);

            var actual = config.Load<string>();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Load_WithSectionName_CallsGetSection_ReturnsResult()
        {
            var configurationSection = Substitute.For<IConfigurationSection>();
            var expected = "Expected";
            configurationSection.Get<string>().Returns(expected);
            var config = Substitute.For<IConfiguration>();
            var sectionName = "My section name";
            config.GetSection(sectionName).Returns(configurationSection);

            var actual = config.Load<string>(sectionName);
            Assert.AreEqual(expected, actual);
        }
    }
}