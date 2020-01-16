using System;
using Microsoft.EntityFrameworkCore;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface ISubstituteFactory
    {
        bool CanCreateFor(Type type);
        object CreateSubstitute<T>(Type type) where T : DbContext;
    }
}