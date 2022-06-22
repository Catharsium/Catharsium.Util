using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Catharsium.Util.Testing.Attributes;

public class ExpectedExceptionMessageAttribute : ExpectedExceptionBaseAttribute
{
    private readonly Type exceptionType;
    private readonly string messageSubstring;


    public ExpectedExceptionMessageAttribute(Type exceptionType, string messageSubstring)
    {
        this.exceptionType = exceptionType;
        this.messageSubstring = messageSubstring;
    }


    protected override void Verify(Exception exception)
    {
        Assert.AreEqual(this.exceptionType, exception.GetType());
        Assert.IsTrue(exception.Message.Contains(this.messageSubstring));
    }


    public void Validate(Exception exception)
    {
        this.Verify(exception);
    }
}