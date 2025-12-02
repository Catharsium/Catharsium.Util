namespace Catharsium.Util.Testing.Tests._Mocks;

public class MockObjectWithDifferentDependencies
{
    public readonly IMockInterface1 InterfaceDependency1;
    public readonly IMockInterface2 InterfaceDependency2;
    public readonly string StringDependency;


    public MockObjectWithDifferentDependencies(IMockInterface1 interface1) {
        this.InterfaceDependency1 = interface1;
    }


    public MockObjectWithDifferentDependencies(IMockInterface2 interface2, string stringDependency) {
        this.InterfaceDependency2 = interface2;
        this.StringDependency = stringDependency;
    }
}