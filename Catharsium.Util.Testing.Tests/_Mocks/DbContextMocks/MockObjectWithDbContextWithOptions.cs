using Catharsium.Util.Testing.Tests._Mocks.DbContextMocks;

namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObjectWithDbContextWithOptions
    {
        public MockDbContextWithOptions DbContext { get; }


        public MockObjectWithDbContextWithOptions(MockDbContextWithOptions dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}