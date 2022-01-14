namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockObjectWithDbContextNoOptions
{
    public MockDbContextWithOptions DbContext { get; }


    public MockObjectWithDbContextNoOptions(MockDbContextWithOptions dbContext)
    {
        this.DbContext = dbContext;
    }
}