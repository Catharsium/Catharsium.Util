using System;
using System.Globalization;

namespace Catharsium.Util.Strings
{
    public static class StringDateHelper
    {
        public static DateTime ToDate(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) { return default(DateTime); }

            if (DateTime.TryParseExact(input, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }

            if (DateTime.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            return default(DateTime);
        }
    }
}