using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Console.Wrappers;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.IO.Console.Tests.Wrappers.ExtendedConsoleTests
{
    [TestClass]
    public class FillSectionsTests : TestFixture<ExtendedConsole>
    {
        [TestMethod]
        public void FillSection_TextLengthLessThanSecion_AddsFiller()
        {
            var text = "My text";
            var fillerLength = 3;
            var sectionLength = text.Length + fillerLength;
            var filler = '!';

            this.Target.FillSection(text.Length, sectionLength, filler);
            this.GetDependency<IConsoleWrapper>().Received(fillerLength).Write(filler.ToString());
        }


        [TestMethod]
        public void FillSection_NoFiller_UsesDefault()
        {
            var text = "My text";
            var fillerLength = 3;
            var sectionLength = text.Length + fillerLength;

            this.Target.FillSection(text.Length, sectionLength);
            this.GetDependency<IConsoleWrapper>().Received(fillerLength).Write(' '.ToString());
        }


        [TestMethod]
        public void FillSection_NoSectionLength_UsesDefault()
        {
            var text = "12345";
            this.Target.FillSection(text.Length);
            this.GetDependency<IConsoleWrapper>().Received(8 - text.Length).Write(' '.ToString());
        }


        [TestMethod]
        public void FillSection_TextLengthEqualToSecion_AddsFiller()
        {
            var text = "My text";
            this.Target.FillSection(text.Length, text.Length);
            this.GetDependency<IConsoleWrapper>().DidNotReceive().Write(Arg.Any<string>());
        }
    }
}