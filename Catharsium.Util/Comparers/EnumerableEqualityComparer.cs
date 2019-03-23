using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Comparers
{
    public class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        private readonly IEqualityComparer<T> comparer;


        public EnumerableEqualityComparer(IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }
            this.comparer = comparer;
        }


        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            if (x.Count() != y.Count())
            {
                return false;
            }

            if (this.comparer != null)
            {
                for (var i = 0; i < x.Count(); i++)
                {
                    if (!this.comparer.Equals(x.ElementAt(i), y.ElementAt(i)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        public int GetHashCode(IEnumerable<T> obj)
        {
            return obj.GetHashCode();
        }
    }
}