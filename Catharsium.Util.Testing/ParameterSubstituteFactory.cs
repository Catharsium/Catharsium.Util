using System;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Catharsium.Util.Testing
{
    public class ParameterSubstituteFactory
    {
        public T GetSubstitute<T>() where T : class
        {
            if (typeof(T).IsInterface) {
                return Substitute.For<T>();
            }

            if (typeof(T).IsAssignableFrom(typeof(DbContext))) {
                var optionsBuilder = new DbContextOptionsBuilder<T>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
                return new T(optionsBuilder.Options);
            }

            return default(T);
        }
    }
}