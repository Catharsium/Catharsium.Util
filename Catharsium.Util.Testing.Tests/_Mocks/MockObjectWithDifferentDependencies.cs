namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObjectWithDifferentDependencies
    {
        public readonly IMockInterface1 InterfaceDependency1;
        public readonly IMockInterface2 InterfaceDependency2;
        public readonly string StringDependency;


        public MockObjectWithDifferentDependencies(IMockInterface1 mockInterface1)
        {
            this.InterfaceDependency1 = mockInterface1;
        }


        public MockObjectWithDifferentDependencies(IMockInterface2 mockInterface2, string mockString)
        {
            this.InterfaceDependency2 = mockInterface2;
            this.StringDependency = mockString;
        }
    }
}