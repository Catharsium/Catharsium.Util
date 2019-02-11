using System;
using System.Collections.Generic;
using System.Reflection;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface ITargetFactory<out T> where T : class
    {
        T CreateTarget(Dictionary<Type, object> dependencies);
        
        ConstructorInfo GetLargestEligibleConstructor(Dictionary<Type, object> dependencies = null);

        IEnumerable<ConstructorInfo> GetEligibleConstructors(Dictionary<Type, object> dependencies);
    }
}