using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Tests._Mocks.DbContextMocks
{
    public class MockDbContextWithOptions : DbContext
    {
        public MockDbContextWithOptions(DbContextOptions options) : base(options) { }
    }
}