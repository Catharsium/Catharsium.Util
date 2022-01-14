﻿using Catharsium.Util.Testing.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Catharsium.Util.Testing.DbContext.Substitutes;

public class DbContextSubstituteFactory<T> : ISubstituteFactory where T : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IConstructorFilter constructorFilter;


    public DbContextSubstituteFactory(IConstructorFilter constructorFilter)
    {
        this.constructorFilter = constructorFilter;
    }


    public bool CanCreateFor(Type type)
    {
        return this.GetEligibleConstructors(type).Any()
            && typeof(Microsoft.EntityFrameworkCore.DbContext).GetTypeInfo().IsAssignableFrom(type)
            && typeof(T) == type;
    }


    public object CreateSubstitute(Type type)
    {
        var constructors = this.GetEligibleConstructors(type);
        if (!constructors.Any()) {
            return null;
        }

        var constructor = constructors.First();
        if (constructor.GetParameters().Length == 1) {
            if (constructor.GetParameters()[0].ParameterType.IsAssignableFrom(typeof(T))) {
                var optionsBuilder = new DbContextOptionsBuilder()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
                return constructor.Invoke(new object[] { optionsBuilder.Options });
            }

            if (constructor.GetParameters()[0].ParameterType.IsAssignableFrom(typeof(DbContextOptions<T>))) {
                var optionsBuilder = new DbContextOptionsBuilder<T>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString());
                return constructor.Invoke(new object[] { optionsBuilder.Options });
            }
        }

        var defaultConstructor = constructors.FirstOrDefault(c => c.GetParameters().Length == 0);
        return defaultConstructor?.Invoke(Array.Empty<object>());
    }


    private List<ConstructorInfo> GetEligibleConstructors(Type type)
    {
        var dependencies = new List<Type> { typeof(DbContextOptions), typeof(DbContextOptions<T>) };
        var constructors = this.constructorFilter
            .GetEligibleConstructors(type, dependencies)
            .OrderByDescending(c => c.GetParameters().Length)
            .ToList();
        return constructors;
    }
}