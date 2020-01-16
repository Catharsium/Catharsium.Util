using System;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface ISubstituteService
    {
        object GetSubstitute(Type type);
    }
}