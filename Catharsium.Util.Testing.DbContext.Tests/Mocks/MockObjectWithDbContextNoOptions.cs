namespace Catharsium.Util.Testing.Databases.Tests.Mocks
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