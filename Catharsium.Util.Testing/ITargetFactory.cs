using System;
using System.Collections.Generic;
using System.Reflection;

namespace Catharsium.Util.Testing
{
    public interface ITargetFactory<T> where T : class
    {
        T CreateTarget(Dictionary<Type, object> dependencies);

        Dictionary<Type, object> GetDependencySubstitutes(ConstructorInfo constructor);

        ConstructorInfo GetLargestEligibleConstructor(Dictionary<Type, object> dependencies = null);

        IEnumerable<ConstructorInfo> GetEligibleConstructors(Dictionary<Type, object> dependencies);
    }
}