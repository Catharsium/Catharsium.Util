using Catharsium.Util.IO.Files._Configuration;
using Catharsium.Util.IO.Files.Csv;
using Catharsium.Util.IO.Files.Interfaces;
using Catharsium.Util.IO.Files.Json;
using Catharsium.Util.IO.Files.Wrappers;
using Catharsium.Util.Testing.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
namespace Catharsium.Util.IO.Files.Tests._Configuration;

[TestClass]
public class RegistrationTests
{
    [TestMethod]
    public void AddIoUtilities_RegistersDependencies()
    {
        var serviceCollection = Substitute.For<IServiceCollection>();
        var config = Substitute.For<IConfiguration>();

        serviceCollection.AddFilesIoUtilities(config);
        serviceCollection.ReceivedRegistration<IFileFactory, FileFactory>();

        serviceCollection.ReceivedRegistration<IJsonFileReader, JsonFileReader>();
        serviceCollection.ReceivedRegistration<IJsonFileWriter, JsonFileWriter>();

        serviceCollection.ReceivedRegistration<ICsvReader, CsvReader>();
        //serviceCollection.ReceivedRegistration<ICsvFileWriter, CsvFileWriter>();
        //serviceCollection.ReceivedRegistration<ICsvWriterFactory, CsvWriterFactory>();
    }
}