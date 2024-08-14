using Microsoft.EntityFrameworkCore;
namespace Catharsium.Util.Testing.DbContext.Tests.Mocks;

public class MockDbContextWithTypedOptions(DbContextOptions<MockDbContextWithTypedOptions> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
}