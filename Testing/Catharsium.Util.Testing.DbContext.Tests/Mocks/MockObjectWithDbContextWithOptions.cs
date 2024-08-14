namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockObjectWithDbContextWithOptions(MockDbContextWithOptions dbContext)
{
    public MockDbContextWithOptions DbContext { get; } = dbContext;
}