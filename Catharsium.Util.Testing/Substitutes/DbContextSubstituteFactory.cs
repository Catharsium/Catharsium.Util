using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Substitutes
{
    public class DbContextSubstituteFactory : IDbContextSubstituteFactory
    {
        private readonly IConstructorFilter constructorFilter;


        public DbContextSubstituteFactory(IConstructorFilter constructorFilter)
        {
            this.constructorFilter = constructorFilter;
        }


        public object CreateDbContextSubstitute<T>(Type type) where T : DbContext
        {
            var dependencies = new List<Type> { typeof(DbContextOptions), typeof(DbContextOptions<T>) };
            var constructors = this.constructorFilter.GetEligibleConstructors(type, dependencies).OrderByDescending(c => c.GetParameters().Length).ToList();
            if (constructors.Any())
            {
                var constructor = constructors.First();
                if (constructor.GetParameters().Length == 1)
                {
                    if (constructor.GetParameters()[0].ParameterType.IsAssignableFrom(typeof(DbContextOptions))) {
                        var optionsBuilder = new DbContextOptionsBuilder()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString());
                        return constructor.Invoke(new object[] {optionsBuilder.Options});
                    }
                    if (constructor.GetParameters()[0].ParameterType.IsAssignableFrom(typeof(DbContextOptions<T>))) {
                        var optionsBuilder = new DbContextOptionsBuilder<T>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString());
                        return constructor.Invoke(new object[] { optionsBuilder.Options });
                    }
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