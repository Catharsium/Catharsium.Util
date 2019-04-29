using System;
using Catharsium.Util.Testing.Tests._Mocks.DbContextMocks;

namespace Catharsium.Util.Testing.Tests._Mocks
{
    class MockObjectWithAllSupportedDependencies
    {
        public readonly IMockInterface1 InterfaceDependency1;
        public readonly IMockInterface2 InterfaceDependency2;
        public readonly MockDbContextNoOptions DbContextNoOptionsDependency;
        public readonly MockDbContextWithOptions DbContextWithOptionsDependency;
        public readonly Guid guidDependency;
        public readonly string StringDependency;


        public MockObjectWithAllSupportedDependencies(IMockInterface1 interface1Dependency)
        {
            this.InterfaceDependency1 = interface1Dependency;
        }


        public MockObjectWithAllSupportedDependencies(
            IMockInterface2 interface2Dependency,
            MockDbContextNoOptions dbContextNoOptionsDependency,
            MockDbContextWithOptions dbContextWithOptions,
            Guid guidDependency)
        {
            this.InterfaceDependency2 = interface2Dependency;
            this.DbContextNoOptionsDependency = dbContextNoOptionsDependency;
            this.DbContextWithOptionsDependency = dbContextWithOptions;
            this.guidDependency = guidDependency;
        }


        public MockObjectWithAllSupportedDependencies(
            IMockInterface2 interface2Dependency,
            MockDbContextNoOptions dbContextNoOptionsDependency,
            MockDbContextWithOptions dbContextWithOptionsDependency,
            Guid guidDependency,
            string stringDependency)
        : this(interface2Dependency, dbContextNoOptionsDependency, dbContextWithOptionsDependency, guidDependency)
        {
            this.StringDependency = stringDependency;
        }
    }
}