using System;

namespace Catharsium.Util.Strings;

public static class StringGuidExtensions
{
    public static Guid ToGuid(this string input) {
        return Guid.TryParse(input, out var result)
            ? result
            : default;
    }


    public static bool IsGuid(this string text) {
        return Guid.TryParse(text, out _);
    }
}