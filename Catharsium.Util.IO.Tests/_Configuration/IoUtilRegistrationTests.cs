using Catharsium.Util.IO._Configuration;
using Catharsium.Util.IO.Console;
using Catharsium.Util.IO.Csv;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Json;
using Catharsium.Util.IO.Wrappers;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.IO.Tests._Configuration
{
    [TestClass]
    public class IoUtilRegistrationTests
    {
        [TestMethod]
        public void AddIoUtilities_RegistersDependencies()
        {
            var serviceCollection = Substitute.For<IServiceCollection>();
            var config = Substitute.For<IConfiguration>();

            serviceCollection.AddIoUtilities(config);
            serviceCollection.ReceivedRegistration<IFileFactory, FileFactory>();
            serviceCollection.ReceivedRegistration<IJsonFileWriter, JsonFileWriter>();
            serviceCollection.ReceivedRegistration<IJsonFileReader, JsonFileReader>();

            serviceCollection.ReceivedRegistration<IConsoleWrapper, SystemConsoleWrapper>();
            serviceCollection.ReceivedRegistration<IConsole, ExtendedConsole>();

            serviceCollection.ReceivedRegistration<ICsvParser, CsvParser>();
        }
    }
}