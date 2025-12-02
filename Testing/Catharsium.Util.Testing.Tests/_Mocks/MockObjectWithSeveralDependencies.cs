namespace Catharsium.Util.Testing.Tests._Mocks;

public class MockObjectWithSeveralDependencies(int intDependency)
{
    public int IntDependency { get; } = intDependency;
    public double DoubleDependency { get; }


    public MockObjectWithSeveralDependencies(int intDependency, double doubleDependency) : this(intDependency) {
        this.DoubleDependency = doubleDependency;
    }
}