using System;
using System.Collections.Generic;

namespace Catharsium.Util.IO.Interfaces
{
    public interface ITypesLoader
    {
        IEnumerable<Type> Load<T>(string folder);
    }
}