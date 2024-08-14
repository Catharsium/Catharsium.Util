using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Util.Testing.Attributes;

public class ExpectedExceptionMessageAttribute(Type exceptionType, string messageSubstring) : ExpectedExceptionBaseAttribute
{
    private readonly Type exceptionType = exceptionType;
    private readonly string messageSubstring = messageSubstring;


    protected override void Verify(Exception exception) {
        Assert.AreEqual(this.exceptionType, exception.GetType());
        Assert.IsTrue(exception.Message.Contains(this.messageSubstring));
    }


    public void Validate(Exception exception) {
        this.Verify(exception);
    }
}