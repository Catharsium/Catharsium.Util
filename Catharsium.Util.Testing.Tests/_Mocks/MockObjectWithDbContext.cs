using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObjectWithDbContext
    {
        public MockDbContext DbContext { get; }


        public MockObjectWithDbContext(MockDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }



    public class MockDbContext : DbContext
    {
    }
}