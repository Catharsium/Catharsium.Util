using Catharsium.Util.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Tests.Strings
{
    [TestClass]
    public class StringCapitalizationExtensionsTests
    {
        #region Capitalize

        [TestMethod]
        public void Capitalize_FirstLetterLowerCase_IsReplacedWithCapital()
        {
            var actual = "expected".Capitalize();
            Assert.AreEqual("Expected", actual);
        }


        [TestMethod]
        public void Capitalize_FirstLetterUpperCase_IsNotChanged()
        {
            var expected = "Expected";
            var actual = expected.Capitalize();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Decapitalize

        [TestMethod]
        public void Decapitalize_FirstLetterLowerCase_IsNotChanged()
        {
            var expected = "expected";
            var actual = expected.Decapitalize();
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Decapitalize_FirstLetterUpperCase_IsReplacedWithCapital()
        {
            var actual = "Expected".Decapitalize();
            Assert.AreEqual("expected", actual);
        }

        #endregion

        #region ToCamelCase

        [TestMethod]
        public void ToCamelCase_LowerCasePhrase_ReturnsAsCamelCase()
        {
            var expected = "My Lower Case Phrase";
            var actual = expected.ToLower().ToCamelCase();
            Assert.AreEqual(expected.Replace(" ", ""), actual);
        }


        [TestMethod]
        public void ToCamelCase_CamelCasePhrase_ReturnsUnchanged()
        {
            var expected = "My Lower Case Phrase";
            var actual = expected.ToCamelCase();
            Assert.AreEqual(expected.Replace(" ", ""), actual);
        }

        #endregion
    }
}