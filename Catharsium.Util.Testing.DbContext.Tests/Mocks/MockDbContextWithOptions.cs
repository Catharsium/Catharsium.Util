using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Databases.Tests.Mocks
{
    public class MockDbContextWithOptions : DbContext
    {
        public MockDbContextWithOptions(DbContextOptions options) : base(options) { }
    }
}