using Catharsium.Util.Math.Interfaces;
using static System.Math;

namespace Catharsium.Util.Math.Numbers
{
    public class NearestRounder : IRounder
    {
        public decimal Round(decimal input, int decimals = 0)
        {
            var factor = (int)Pow(10, decimals);
            var integralValue = input * factor;
            var roundedValue = System.Math.Round(integralValue);
            return roundedValue / factor;
        }
    }
}