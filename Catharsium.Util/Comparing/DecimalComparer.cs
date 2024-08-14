namespace Catharsium.Util.Comparing;

public class DecimalComparer : IComparer<decimal>
{
    public int Compare(decimal x, decimal y) {
        return x < y
            ? -1
            : x == y
                ? 0
                : 1;
    }
}