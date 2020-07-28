using System;
using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.Interfaces;

namespace Catharsium.Util.Types
{
    public class TypesRetriever : ITypesRetriever
    {
        public IEnumerable<Type> GetImplementationsFor<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
        }
    }
}