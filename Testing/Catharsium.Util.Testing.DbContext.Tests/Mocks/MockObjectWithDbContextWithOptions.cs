namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockObjectWithDbContextWithOptions
{
    public MockDbContextWithOptions DbContext { get; }


    public MockObjectWithDbContextWithOptions(MockDbContextWithOptions dbContext)
    {
        this.DbContext = dbContext;
    }
}