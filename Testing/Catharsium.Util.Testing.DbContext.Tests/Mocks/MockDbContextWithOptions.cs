using Microsoft.EntityFrameworkCore;
namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockDbContextWithOptions : Microsoft.EntityFrameworkCore.DbContext
{
    public MockDbContextWithOptions(DbContextOptions options) : base(options)
    {
    }
}