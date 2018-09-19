using System;

namespace Catharsium.Util.Strings
{
    public static class StringGuidHelper
    {
        public static Guid ToGuid(this string input)
        {
            if (Guid.TryParse(input, out var result))
            { return result; }

            return default(Guid);
        }
    }
} 