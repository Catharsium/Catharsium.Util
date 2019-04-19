using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.Testing.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Substitutes
{
    public class DbContextSubstituteFactory : IDbContextSubstituteFactory
    {
        public object CreateDbContextSubstitute(Type type)
        {
            var dependencies = new List<Type> { typeof(DbContextOptions) };
            var constructors = new ConstructorFilter<T>().GetEligibleConstructors(dependencies).OrderByDescending(c => c.GetParameters().Length);
            if (constructors.Any())
            {
                var constructor = constructors.FirstOrDefault();
                if (constructor.GetParameters().Length > 0)
                {
                    var optionsBuilder = new DbContextOptionsBuilder()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString());
                    return constructor.Invoke(new object[] { optionsBuilder.Options });
                }

                var defaultConstructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 0);
                if (defaultConstructor != null)
                {
                    return defaultConstructor.Invoke(new object[0]);
                }
            }
            return null;
        }
    }
}