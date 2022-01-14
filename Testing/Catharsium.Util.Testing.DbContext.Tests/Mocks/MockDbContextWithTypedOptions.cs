using Microsoft.EntityFrameworkCore;
namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockDbContextWithTypedOptions : Microsoft.EntityFrameworkCore.DbContext
{
    public MockDbContextWithTypedOptions(DbContextOptions<MockDbContextWithTypedOptions> options) : base(options)
    {
    }
}