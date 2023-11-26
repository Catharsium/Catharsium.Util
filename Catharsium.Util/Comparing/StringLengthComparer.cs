using System.Collections.Generic;

namespace Catharsium.Util.Comparing;

public class StringLengthComparer : IComparer<string>
{
    private readonly IComparer<int> intComparer;


    public StringLengthComparer(IComparer<int> intComparer) {
        this.intComparer = intComparer;
    }


    public int Compare(string x, string y) {
        return x == null || y == null
            ? 0
            : this.intComparer.Compare(x.Length, y.Length);
    }
}