using System;
using System.Collections.Generic;
using System.Reflection;

namespace Catharsium.Util.Testing
{
    public interface ITargetFactory<T> where T : class
    {
        T CreateTarget(Dictionary<Type, object> dependencies);

        ConstructorInfo GetLargestEligibleConstructor(Dictionary<Type, object> dependencies);

        IEnumerable<ConstructorInfo> GetEligibleConstructors(Dictionary<Type, object> dependencies);
    }
}