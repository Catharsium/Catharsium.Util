using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Attributes
{
    public class ExpectedExceptionAttribute : ExpectedExceptionBaseAttribute
    {
        public Type ExceptionType { get; }


        public ExpectedExceptionAttribute(Type exceptionType)
        {
            this.ExceptionType = exceptionType;
        }


        protected override void Verify(Exception exception)
        {
            Assert.AreEqual(this.ExceptionType, exception);
        }
    }
}