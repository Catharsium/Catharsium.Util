using Catharsium.Util.Testing.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface IDependencyRetriever
    {
        List<Dependency> GetDependencySubstitutes<T>();
        List<Dependency> GetDependencySubstitutes(ConstructorInfo constructor, List<Dependency> substitutes);
        List<Dependency> GetDependencies<T>();
        Dictionary<Type, object> GetSubstitutes(IEnumerable<Type> dependencies);
    }
}