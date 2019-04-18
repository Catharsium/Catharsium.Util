using System;
using Catharsium.Util.Testing.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Substitutes
{
    public class DbContextSubstituteFactory : IDbContextSubstituteFactory
    {
        public object CreateDbContextSubstitute<T>()
        {
            var constructor = new ConstructorFilter<T>().GetEligibleConstructors(null);
            var optionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            return typeof(T).GetConstructors()[0].Invoke(new object[] { optionsBuilder.Options });
        }
    }
}