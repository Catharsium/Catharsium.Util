using System;

namespace Catharsium.Util.Testing.Substitutes
{
    public interface IDbContextSubstituteFactory
    {
        object CreateDbContextSubstitute<T>();
    }
}