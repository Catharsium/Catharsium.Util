using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Comparing.Equality;

public class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
{
    private readonly IEqualityComparer<T> comparer;


    public EnumerableEqualityComparer(IEqualityComparer<T> comparer = null)
    {
        if (comparer == null) {
            comparer = EqualityComparer<T>.Default;
        }

        this.comparer = comparer;
    }


    public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
    {
        if (x == null || y == null) {
            return false;
        }

        var arrayX = x.ToArray();
        var arrayY = y.ToArray();
        return arrayX.Length == arrayY.Length
            && (this.comparer == null
            || !arrayX.Where((t, i) => !this.comparer.Equals(arrayX.ElementAt(i), arrayY.ElementAt(i))).Any());
    }


    public int GetHashCode(IEnumerable<T> obj)
    {
        return obj.GetHashCode();
    }
}