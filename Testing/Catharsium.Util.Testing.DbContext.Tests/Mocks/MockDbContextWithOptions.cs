using Microsoft.EntityFrameworkCore;
namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockDbContextWithOptions(DbContextOptions options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
}