namespace Catharsium.Util.Testing.Tests._Mocks;

public class MockObjectWithSingleConstructor(IMockInterface1 interface1, IMockInterface2 interface2, string stringDependency)
{
    public readonly IMockInterface1 InterfaceDependency1 = interface1;
    public readonly IMockInterface2 InterfaceDependency2 = interface2;
    public readonly string StringDependency = stringDependency;
}