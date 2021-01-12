using Catharsium.Util.IO._Configuration;
using Catharsium.Util.IO.Csv;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Json;
using Catharsium.Util.IO.Types;
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
            serviceCollection.ReceivedRegistration<ITypesLoader, TypesLoader>();

            serviceCollection.ReceivedRegistration<IJsonFileReader, JsonFileReader>();
            serviceCollection.ReceivedRegistration<IJsonFileWriter, JsonFileWriter>();

            serviceCollection.ReceivedRegistration<ICsvFileWriter, CsvFileWriter>();
            serviceCollection.ReceivedRegistration<ICsvReader, CsvReader>();
            serviceCollection.ReceivedRegistration<ICsvWriterFactory, CsvWriterFactory>();
        }
    }
}