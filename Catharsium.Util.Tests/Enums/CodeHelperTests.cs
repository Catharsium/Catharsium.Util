using Catharsium.Util.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catharsium.Util.Tests.Enums
{
    [TestClass]
    public class CodeHelperTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetByCode_NullCode_ThrowsException()
        {
            MockEnum.GetByCode(null);
        }
    }
}
