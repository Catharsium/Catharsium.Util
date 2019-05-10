using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Tests._Mocks.DbContextMocks
{
    public class MockDbContextWithTypedOptions : DbContext
    {
        public MockDbContextWithTypedOptions(DbContextOptions<MockDbContextWithTypedOptions> options) : base(options) { }
    }
}