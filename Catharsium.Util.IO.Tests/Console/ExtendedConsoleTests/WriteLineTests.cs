using Catharsium.Util.IO.Console;
using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace Catharsium.Util.IO.Tests.Console.ExtendedConsoleTests
{
    [TestClass]
    public class WriteLineTests : TestFixture<ExtendedConsole>
    {
        [TestMethod]
        public void WriteLine_MessageAndColor_WritesMessageAndResetsColor()
        {
            var message = "My message";
            var color = ConsoleColor.Red;
            
            this.Target.WriteLine(message, color);
            this.GetDependency<IConsoleWrapper>().Received().Write(message);
            this.GetDependency<IConsoleWrapper>().Received().ResetColor();
        }
    }
}