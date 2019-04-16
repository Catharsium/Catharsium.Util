using System;
using System.Reflection;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Catharsium.Util.Testing.Substitutes
{
    public class SubstituteFactory : ISubstituteFactory
    {
        public object GetSubstitute<T>() where T : class
        {
            if (typeof(T).GetTypeInfo().IsInterface) {
                return Substitute.For<T>();
            }

            if (typeof(T) == typeof(Guid)) {
                return Guid.NewGuid();
            }

            if (typeof(DbContext).GetTypeInfo().IsAssignableFrom(typeof(T))) { return new DbContextSubstituteFactory().CreateDbContextSubstitute(typeof(T)); }

            return default(T);
        }

    }
}