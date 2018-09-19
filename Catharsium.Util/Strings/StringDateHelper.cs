using System;
using System.Globalization;

namespace Catharsium.Util.Strings
{
    public static class StringDateHelper
    {
        private static readonly string[] supportedFormats = new [] { "yyyyMMdd", "yyyyMMddHHmmss" };


        public static DateTime ToDate(this string input)
        {
            var result = default(DateTime);
            if (string.IsNullOrWhiteSpace(input)) { return result; }

            foreach (var format in supportedFormats)
            {
                if (DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                { return result; }
            }

            if (DateTime.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            { return result; }

            return default(DateTime);
        }
    }
}