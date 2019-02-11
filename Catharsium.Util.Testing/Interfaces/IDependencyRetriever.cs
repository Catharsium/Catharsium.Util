using System;
using System.Collections.Generic;
using System.Reflection;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface IDependencyRetriever
    {
        Dictionary<Type, object> GetDependencySubstitutes<T>();
        Dictionary<Type, object> GetDependencySubstitutes(ConstructorInfo constructor, Dictionary<Type, object> substitutes);
        IEnumerable<Type> GetDependencies<T>();
        Dictionary<Type, object> GetSubstitutes(IEnumerable<Type> dependencies);
    }
}