using System;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface IDbContextSubstituteFactory
    {
        object CreateDbContextSubstitute(Type type);
    }
}