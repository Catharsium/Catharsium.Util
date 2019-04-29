namespace Catharsium.Util.Testing.Tests._Mocks.DbContextMocks
{
    public class MockObjectWithDbContextNoOptions
    {
        public MockDbContextWithOptions DbContext { get; }


        public MockObjectWithDbContextNoOptions(MockDbContextWithOptions dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}