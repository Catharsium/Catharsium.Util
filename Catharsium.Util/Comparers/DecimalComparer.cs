using System.Collections.Generic;

namespace Catharsium.Util.Comparers
{
    public class DecimalComparer : IComparer<decimal>
    {
        public int Compare(decimal x, decimal y)
        {
            if (x < y) {
                return -1;
            }

            return x == y ? 0 : 1;
        }
    }
}