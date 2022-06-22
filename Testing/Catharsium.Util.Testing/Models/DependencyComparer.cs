using System.Collections.Generic;

namespace Catharsium.Util.Testing.Models;

public class DependencyComparer : IEqualityComparer<Dependency>
{
    public bool Equals(Dependency x, Dependency y)
    {
        return x != null
            && y != null
            && x.Type == y.Type
            && x.Name == y.Name;
    }


    public int GetHashCode(Dependency obj)
    {
        return obj.GetHashCode();
    }
}