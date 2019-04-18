using System;
using System.Collections.Generic;

namespace Catharsium.Util.Testing.Interfaces
{
    public interface ITargetFactory<out T> where T : class
    {
        T CreateTarget(Dictionary<Type, object> dependencies);
    }
}