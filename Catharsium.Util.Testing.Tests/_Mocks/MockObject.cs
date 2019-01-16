namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObject
    {
        public readonly IMockInterface1 interfaceDependency1;
        public readonly IMockInterface2 interfaceDependency2;
        public readonly string stringDependency;


        public MockObject(IMockInterface1 mockInterface1)
        {
            this.interfaceDependency1 = mockInterface1;
        }


        public MockObject(IMockInterface1 mockInterface1, IMockInterface2 mockInterface2)
            : this(mockInterface1)
        {
            this.interfaceDependency2 = mockInterface2;
        }


        public MockObject(IMockInterface1 mockInterface1, IMockInterface2 mockInterface2, string mockString)
           : this(mockInterface1, mockInterface2)
        {
            this.stringDependency = mockString;
        }
    }
}