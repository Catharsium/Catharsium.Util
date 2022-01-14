using Catharsium.Util.Testing.Tests._Mocks;
using System;
namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockObjectWithDbContextDependencies
{
    public readonly IMockInterface1 InterfaceDependency1;
    public readonly IMockInterface2 InterfaceDependency2;
    public readonly MockDbContextNoOptions DbContextNoOptionsDependency;
    public readonly MockDbContextWithOptions DbContextWithOptionsDependency;
    public readonly MockDbContextWithTypedOptions DbContextWithTypedOptions;
    public readonly Guid GuidDependency;
    public readonly string StringDependency;


    public MockObjectWithDbContextDependencies(IMockInterface1 interface1Dependency)
    {
        this.InterfaceDependency1 = interface1Dependency;
    }


    public MockObjectWithDbContextDependencies(
        IMockInterface2 interface2Dependency,
        MockDbContextNoOptions dbContextNoOptionsDependency,
        MockDbContextWithOptions dbContextWithOptions,
        MockDbContextWithTypedOptions dbContextWithTypedOptions,
        Guid guidDependency)
    {
        this.InterfaceDependency2 = interface2Dependency;
        this.DbContextNoOptionsDependency = dbContextNoOptionsDependency;
        this.DbContextWithOptionsDependency = dbContextWithOptions;
        this.DbContextWithTypedOptions = dbContextWithTypedOptions;
        this.GuidDependency = guidDependency;
    }


    public MockObjectWithDbContextDependencies(
        IMockInterface2 interface2Dependency,
        MockDbContextNoOptions dbContextNoOptionsDependency,
        MockDbContextWithOptions dbContextWithOptionsDependency,
        MockDbContextWithTypedOptions dbContextWithTypedOptions,
        Guid guidDependency,
        string stringDependency)
        : this(interface2Dependency, dbContextNoOptionsDependency, dbContextWithOptionsDependency, dbContextWithTypedOptions, guidDependency)
    {
        this.StringDependency = stringDependency;
    }
}