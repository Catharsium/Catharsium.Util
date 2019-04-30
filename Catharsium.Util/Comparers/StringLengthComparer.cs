using System.Collections.Generic;

namespace Catharsium.Util.Comparers
{
    public class StringLengthComparer : IComparer<string>
    {
        private readonly IComparer<int> intComparer;


        public StringLengthComparer(IComparer<int> intComparer)
        {
            this.intComparer = intComparer;
        }


        public int Compare(string x, string y)
        {
            if (x == null || y == null) {
                return 0;
            }

            return this.intComparer.Compare(x.Length, y.Length);
        }
    }
}