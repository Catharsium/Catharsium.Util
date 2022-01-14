using Catharsium.Util.Reflection.Attributes;
namespace Catharsium.Util.Tests._Mocks;

public class MockMethod
{
    [Alias("My alias")]
    public void MethodWithAlias() { }

    public void MethodWithoutAlias() { }
}