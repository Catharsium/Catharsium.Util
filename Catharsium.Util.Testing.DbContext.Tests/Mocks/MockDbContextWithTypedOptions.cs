using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Databases.Tests.Mocks
{
    public class MockDbContextWithTypedOptions : DbContext
    {
        public MockDbContextWithTypedOptions(DbContextOptions<MockDbContextWithTypedOptions> options) : base(options) { }
    }
}