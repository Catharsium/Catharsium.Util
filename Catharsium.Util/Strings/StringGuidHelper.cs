using System;

namespace Catharsium.Util.Strings
{
    public static class StringGuidHelper
    {
        public static Guid ToGuid(this string input)
        {
            return Guid.TryParse(input, out var result)
                ? result
                : default;
        }
    }
}