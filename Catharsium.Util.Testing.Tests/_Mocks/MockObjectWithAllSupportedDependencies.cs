using System;

namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObjectWithAllSupportedDependencies
    {
        public readonly IMockInterface1 InterfaceDependency1;
        public readonly IMockInterface2 InterfaceDependency2;
        public readonly Guid GuidDependency;
        public readonly string StringDependency;


        public MockObjectWithAllSupportedDependencies(IMockInterface1 interface1Dependency)
        {
            this.InterfaceDependency1 = interface1Dependency;
        }


        public MockObjectWithAllSupportedDependencies(
            IMockInterface2 interface2Dependency,
            Guid guidDependency)
        {
            this.InterfaceDependency2 = interface2Dependency;
            this.GuidDependency = guidDependency;
        }


        public MockObjectWithAllSupportedDependencies(
            IMockInterface2 interface2Dependency,
            Guid guidDependency,
            string stringDependency)
            : this(interface2Dependency, guidDependency)
        {
            this.StringDependency = stringDependency;
        }
    }
}