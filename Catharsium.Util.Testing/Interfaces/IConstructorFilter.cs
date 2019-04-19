using System;
using System.Collections.Generic;
using System.Reflection;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface IConstructorFilter<T>
    {
        ConstructorInfo GetLargestEligibleConstructor(Dictionary<Type, object> dependencies = null);

        IEnumerable<ConstructorInfo> GetEligibleConstructors(Dictionary<Type, object> dependencies);

        IEnumerable<ConstructorInfo> GetEligibleConstructors(IEnumerable<Type> dependencies);
    }
}