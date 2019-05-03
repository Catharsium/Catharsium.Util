using Catharsium.Util.Math.Interfaces;

namespace Catharsium.Util.Math.Numbers
{
    public class FlooringRounder : IRounder
    {
        public decimal Round(decimal input, int decimals = 0)
        {
            var factor = (int)System.Math.Pow(10, decimals);
            var integralValue = input * factor;
            var roundedValue = System.Math.Floor(integralValue);
            return roundedValue / factor;
        }
    }
}