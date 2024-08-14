namespace Catharsium.Util.Comparing;

public class StringLengthComparer(IComparer<int> intComparer) : IComparer<string>
{
    private readonly IComparer<int> intComparer = intComparer;


    public int Compare(string x, string y) {
        return x == null || y == null
            ? 0
            : this.intComparer.Compare(x.Length, y.Length);
    }
}