using System;
using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface IDbContextSubstituteFactory
    {
        object CreateDbContextSubstitute<T>(Type type) where T : DbContext;
    }
}