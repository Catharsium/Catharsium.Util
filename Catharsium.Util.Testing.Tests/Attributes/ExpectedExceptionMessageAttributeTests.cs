using System;
using System.Collections.Generic;
using Catharsium.Util.Testing.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Tests.Attributes
{
    [TestClass]
    public class ExpectedExceptionMessageAttributeTests : TestFixture<ExpectedExceptionMessageAttribute>
    {
        [TestMethod]
        public void Verify_EqualTypeAndMessage_DoesNotThrowAnyException()
        {
            var exception = new KeyNotFoundException("My message");
            this.SetDependency(exception.GetType());
            this.SetDependency(exception.Message);
            this.Target.Validate(exception);
        }


        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Verify_SubstringOfMessage_DoesNotThrowAnyException()
        {
            var exception = new KeyNotFoundException("My message");
            this.SetDependency(exception.GetType());
            this.SetDependency(exception.Message + "Larger message");
            this.Target.Validate(exception);
        }


        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Verify_MessageNotContainedInExpected_ThrowsException()
        {
            var exception = new KeyNotFoundException("My message");
            this.SetDependency(exception.GetType());
            this.SetDependency("Other message");
            this.Target.Validate(exception);
        }


        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Verify_OtherType_ThrowsException()
        {
            var exception = new KeyNotFoundException("My message");
            this.SetDependency(typeof(ArgumentOutOfRangeException));
            this.SetDependency(exception.Message);
            this.Target.Validate(exception);
        }
    }
}