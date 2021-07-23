using Catharsium.Util.Time.Format;

namespace Catharsium.Util.Interfaces
{
    public interface ITimeFormatParser
    {
        TimePeriod Parse(int quantity, string type);
        TimePeriod Parse(string format);
    }
}