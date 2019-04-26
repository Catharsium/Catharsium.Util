using System;
using System.Collections.Generic;
using System.Reflection;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface IConstructorFilter
    {
        ConstructorInfo GetLargestEligibleConstructor(Type type, Dictionary<Type, object> dependencies = null);

        IEnumerable<ConstructorInfo> GetEligibleConstructors(Type type, Dictionary<Type, object> dependencies);

        IEnumerable<ConstructorInfo> GetEligibleConstructors(Type type, IEnumerable<Type> dependencies);
    }
}