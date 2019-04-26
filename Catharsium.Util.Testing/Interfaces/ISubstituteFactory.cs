using System;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface ISubstituteFactory
    {
        object GetSubstitute(Type type);
    }
}