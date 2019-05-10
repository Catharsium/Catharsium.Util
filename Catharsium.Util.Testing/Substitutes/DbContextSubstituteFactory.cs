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


        public object CreateDbContextSubstitute(Type type)
        {
            var dependencies = new List<Type> { typeof(DbContextOptions) };
            var constructors = this.constructorFilter.GetEligibleConstructors(type, dependencies).OrderByDescending(c => c.GetParameters().Length).ToList();
            if (constructors.Any())
            {
                var constructor = constructors.First();
                if (constructor.GetParameters().Length == 1)
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