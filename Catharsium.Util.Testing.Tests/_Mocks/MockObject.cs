namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObject
    {
        public readonly IMockInterface1 InterfaceDependency1;
        public readonly IMockInterface2 InterfaceDependency2;
        public readonly string StringDependency;


        public MockObject(IMockInterface1 interface1)
        {
            this.InterfaceDependency1 = interface1;
        }


        public MockObject(IMockInterface1 interface1, IMockInterface2 interface2)
            : this(interface1)
        {
            this.InterfaceDependency2 = interface2;
        }


        public MockObject(IMockInterface1 interface1, IMockInterface2 interface2, string stringDependency)
           : this(interface1, interface2)
        {
            this.StringDependency = stringDependency;
        }
    }
}