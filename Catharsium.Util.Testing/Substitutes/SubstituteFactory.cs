using System;
using System.Reflection;
using Catharsium.Util.Testing.Interfaces;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace Catharsium.Util.Testing.Substitutes
{
    public class SubstituteFactory : ISubstituteFactory
    {
        private readonly IDbContextSubstituteFactory dbContextSubstituteFactory;


        public SubstituteFactory(IDbContextSubstituteFactory dbContextSubstituteFactory)
        {
            this.dbContextSubstituteFactory = dbContextSubstituteFactory;
        }


        public object GetSubstitute(Type type)
        {
            if (type.GetTypeInfo().IsInterface) {
                return Substitute.For(new[] { type }, new object[0]);
            }

            if (type == typeof(Guid)) {
                return Guid.NewGuid();
            }

            if (typeof(DbContext).GetTypeInfo().IsAssignableFrom(type)) {
                var method = this.dbContextSubstituteFactory.GetType().GetMethod("CreateDbContextSubstitute");
                method = method?.MakeGenericMethod(type);
                //this.dbContextSubstituteFactory.CreateDbContextSubstitute(type);
                return method?.Invoke(this.dbContextSubstituteFactory, new object[] {type});
            }

            return null;
        }
    }
}