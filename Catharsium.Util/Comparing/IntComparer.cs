namespace Catharsium.Util.Comparing;

public class IntComparer(IComparer<decimal> decimalComparer) : IComparer<int>
{
    private readonly IComparer<decimal> decimalComparer = decimalComparer;


    public int Compare(int x, int y) {
        return this.decimalComparer.Compare(x, y);
    }
}