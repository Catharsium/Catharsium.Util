using System;
using System.Globalization;
using System.Linq;

namespace Catharsium.Util.Strings
{
    public static class StringDateExtensions
    {
        private static readonly string[] SupportedFormats = { "yyyyMMdd", "yyyyMMddHHmmss" };


        public static DateTime ToDate(this string input)
        {
            var result = default(DateTime);
            if (string.IsNullOrWhiteSpace(input)) { return result; }

            if (SupportedFormats.Any(format =>
                DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))) {
                return result;
            }

            return DateTime.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out result)
                ? result
                : default(DateTime);
        }
    }
}