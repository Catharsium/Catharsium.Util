using System;
using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface IDbContextSubstituteFactory
    {
        object CreateSubstitute<T>(Type type) where T : DbContext;
    }
}