using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Json;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Util.IO.Tests.Json
{
    [TestClass]
    public class JsonFileRepositoryTests : TestFixture<JsonFileRepository<string>>
    {
        #region Fixture

        private static string StoragePath => "My storage path";
        private static string FileName => "My file name";


        [TestInitialize]
        public void Initialize()
        {
            this.SetDependency(StoragePath, "storagePath");
        }

        #endregion

        #region LoadAll

        [TestMethod]
        public async Task LoadAll_ReturnsDataFromAllFiles()
        {
            var directory = Substitute.For<IDirectory>();
            var file1 = Substitute.For<IFile>();
            var file2 = Substitute.For<IFile>();
            directory.GetFiles("*.json").Returns(new[] { file1, file2 });
            this.GetDependency<IFileFactory>().CreateDirectory($@"{StoragePath}").Returns(directory);
            var expected1 = new[] { "First data" };
            var expected2 = new[] { "Second data" };
            this.GetDependency<IJsonFileReader>().ReadFrom<IEnumerable<string>>(file1).Returns(expected1);
            this.GetDependency<IJsonFileReader>().ReadFrom<IEnumerable<string>>(file2).Returns(expected2);

            var actual = await this.Target.LoadAll();
            Assert.AreEqual(expected1.Length + expected2.Length, actual.Count());
            foreach (var data in actual)
            {
                Assert.IsTrue(expected1.Contains(data) || expected2.Contains(data));
            }
        }

        #endregion

        #region Load

        [TestMethod]
        public async Task Load_ReturnsDataFromFile()
        {
            var file = Substitute.For<IFile>();
            var expected = Array.Empty<string>();
            this.GetDependency<IFileFactory>().CreateFile($@"{StoragePath}\{FileName}.json").Returns(file);
            this.GetDependency<IJsonFileReader>().ReadFrom<IEnumerable<string>>(file).Returns(expected);

            var actual = await this.Target.Load(FileName);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Store

        [TestMethod]
        public async Task Store_WritesDataToFile()
        {
            var data = Array.Empty<string>();
            await this.Target.Store(data, FileName);
            this.GetDependency<IJsonFileWriter>().Received().Write(data, $@"{StoragePath}\{FileName}.json");
        }

        #endregion
    }
}