namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockObjectWithDbContextNoOptions(MockDbContextWithOptions dbContext)
{
    public MockDbContextWithOptions DbContext { get; } = dbContext;
}