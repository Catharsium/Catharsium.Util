using Catharsium.Util.Math.Interfaces;

namespace Catharsium.Util.Math.Lists
{
    public class ListMultiplicator : IListMultiplicator
    {
        public long Multiply(int[] input)
        {
            if( input.Length == 0) {
                return 0;
            }

            long result = 1;
            foreach(var number in input)
            {
                result *= number;
            }

            return result;
        }
    }
}