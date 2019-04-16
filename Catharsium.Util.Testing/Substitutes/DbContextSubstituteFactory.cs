using System;
using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Substitutes
{
    public class DbContextSubstituteFactory
    {
        public object CreateDbContextSubstitute(Type dbContextType)
        {
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            return dbContextType.GetConstructors()[0].Invoke(new object[] {optionsBuilder.Options});
        }
    }
}