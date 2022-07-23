using Catharsium.Util.IO.Files.Services;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;

namespace Catharsium.Util.IO.Files.Tests.Helpers
{
    [TestClass]
    public class FileNameServiceTests : TestFixture<FileNameService>
    {
        #region SuggestValidFileName

        [TestMethod]
        public void SuggestValidFileName_ValidFileName_ReturnsFileName()
        {
            var fileName = "My file name";
            var actual = this.Target.SuggestValidFileName(fileName);
            Assert.AreEqual("My file name", actual);
        }


        [TestMethod]
        public void SuggestValidFileName_InvalidCharacters_ReplacesInvalidCharactersWithDefaultReplacement()
        {
            var fileName = "My/file:name?";
            var actual = this.Target.SuggestValidFileName(fileName);

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                Assert.AreEqual("My_file:name?", actual);
            }
            else {
                Assert.AreEqual("My_file_name", actual);
            }
        }


        [TestMethod]
        public void SuggestValidFileName_InvalidCharactersAndReplacement_ReplacesInvalidCharactersWithReplacement()
        {
            var fileName = "My/file:name?";
            var actual = this.Target.SuggestValidFileName(fileName, "*");

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                Assert.AreEqual("My*file:name?", actual);
            }
            else {
                Assert.AreEqual("My*file*name", actual);
            }
        }

        #endregion
    }
}