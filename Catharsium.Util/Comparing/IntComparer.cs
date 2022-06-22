using System.Collections.Generic;

namespace Catharsium.Util.Comparing;

public class IntComparer : IComparer<int>
{
    private readonly IComparer<decimal> decimalComparer;


    public IntComparer(IComparer<decimal> decimalComparer)
    {
        this.decimalComparer = decimalComparer;
    }


    public int Compare(int x, int y)
    {
        return this.decimalComparer.Compare(x, y);
    }
}