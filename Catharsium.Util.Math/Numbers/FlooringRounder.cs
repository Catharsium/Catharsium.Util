using Catharsium.Util.Math.Interfaces;
using static System.Math;

namespace Catharsium.Util.Math.Numbers
{
    public class FlooringRounder : IRounder
    {
        public decimal Round(decimal input, int decimals = 0)
        {
            var factor = (int)Pow(10, decimals);
            var integralValue = input * factor;
            var roundedValue = Floor(integralValue);
            return roundedValue / factor;
        }
    }
}