namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObject
    {
        private readonly IMockInterface1 mockInterface1;
        private readonly IMockInterface2 mockInterface2;
        public string StringDependency { get; set; }


        public MockObject(IMockInterface1 mockInterface1)
        {
            this.mockInterface1 = mockInterface1;
        }


        public MockObject(IMockInterface1 mockInterface1, IMockInterface2 mockInterface2)
            : this(mockInterface1)
        {
            this.mockInterface2 = mockInterface2;
        }


        public MockObject(IMockInterface1 mockInterface1, IMockInterface2 mockInterface2, string mockString)
           : this(mockInterface1, mockInterface2)
        {
            this.StringDependency = mockString;
        }
    }
}