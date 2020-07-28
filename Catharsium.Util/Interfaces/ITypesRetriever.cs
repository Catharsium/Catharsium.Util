using System;
using System.Collections.Generic;

namespace Catharsium.Util.Interfaces
{
    public interface ITypesRetriever
    {
        IEnumerable<Type> GetImplementationsFor<T>();
    }
}