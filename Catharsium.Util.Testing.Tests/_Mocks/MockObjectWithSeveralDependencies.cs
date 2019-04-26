namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObjectWithSeveralDependencies
    {
        public int IntDependency { get; }
        public double DoubleDependency { get; }


        public MockObjectWithSeveralDependencies(int intDependency)
        {
            this.IntDependency = intDependency;
        }


        public MockObjectWithSeveralDependencies(int intDependency, double doubleDependency) : this(intDependency)
        {
            this.DoubleDependency = doubleDependency;
        }
    }
}