using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Json;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.IO.Tests.Json
{
    [TestClass]
    public class JsonFileRepositoryTests : TestFixture<JsonFileRepository<string>>
    {
        #region Fixture

        private static string StoragePath => "My storage path";
        private static string Key => "My file name";

        private IFile File { get; set; }


        [TestInitialize]
        public void Initialize()
        {
            this.SetDependency(StoragePath, "storagePath");

            this.File = Substitute.For<IFile>();
            this.GetDependency<IFileFactory>().CreateFile($@"{StoragePath}\{Key}.json").Returns(this.File);
        }

        #endregion

        #region Get

        [TestMethod]
        public async Task Get_NoKey_ReturnsDataFromAllFiles()
        {
            var directory = Substitute.For<IDirectory>();
            var file1 = Substitute.For<IFile>();
            file1.Exists.Returns(true);
            var file2 = Substitute.For<IFile>();
            file2.Exists.Returns(true);
            directory.GetFiles("*.json").Returns(new[] { file1, file2 });
            this.GetDependency<IFileFactory>().CreateDirectory($@"{StoragePath}").Returns(directory);
          
            var expected1 = "My first data";
            var expected2 = "My second data";
            this.GetDependency<IJsonFileReader>().ReadFrom<string>(file1).Returns(expected1);
            this.GetDependency<IJsonFileReader>().ReadFrom<string>(file2).Returns(expected2);

            var actual = await this.Target.Get();
            Assert.AreEqual(2, actual.Count());
            foreach (var data in actual) {
                Assert.IsTrue(expected1.Contains(data) || expected2.Contains(data));
            }
        }

        #endregion

        #region Get(key)

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public async Task Get_NewKey_ThrowsException()
        {
            var expected = "My data";
            this.File.Exists.Returns(false);
            this.GetDependency<IJsonFileReader>().ReadFrom<string>(this.File).Returns(expected);
            await this.Target.Get(Key);
        }


        [TestMethod]
        public async Task Get_ExistingKey_ReturnsDataFromFile()
        {
            var expected = "My data";
            this.File.Exists.Returns(true);
            this.GetDependency<IJsonFileReader>().ReadFrom<string>(this.File).Returns(expected);

            var actual = await this.Target.Get(Key);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Add

        [TestMethod]
        public async Task Add_NewKey_DoesNotDeleteFile_WritesDataToFile()
        {
            var data = "My data";
            this.File.Exists.Returns(false);

            await this.Target.Add(data, Key);
            this.File.DidNotReceive().Delete();
            this.GetDependency<IJsonFileWriter>().Received().Write(data, this.File);
        }


        [TestMethod]
        public async Task Add_ExistingKey_DeletesFile_WritesDataToFile()
        {
            var data = "My data";
            this.File.Exists.Returns(true);

            await this.Target.Add(data, Key);
            this.File.Received().Delete();
            this.GetDependency<IJsonFileWriter>().Received().Write(data, this.File);
        }

        #endregion

        #region Remove

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public async Task Remove_NewKey_ThrowsException()
        {
            this.File.Exists.Returns(false);
            await this.Target.Remove(Key);
        }


        [TestMethod]
        public async Task Remove_ExistingKey_DeletesFile()
        {
            this.File.Exists.Returns(true);
            await this.Target.Remove(Key);
            this.File.Received().Delete();
        }

        #endregion
    }
}