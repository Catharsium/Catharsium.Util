using System;
using System.Globalization;

namespace Catharsium.Util.Enums;

public static class EnumParsingHelper
{
    public static T? ParseNullableEnum<T>(this string value, bool isRequired) where T : struct, IConvertible {
        if (!typeof(T).IsEnum) {
            throw new ArgumentException("T must be an enumerated type");
        }

        if (string.IsNullOrEmpty(value)) {
            return isRequired
                ? throw new ArgumentNullException(typeof(T).Name)
                : null;
        }

        foreach (T item in Enum.GetValues(typeof(T))) {
            if (item.ToString(CultureInfo.InvariantCulture).ToLower().Equals(value.Trim().ToLower())) {
                return item;
            }
        }

        throw new ArgumentException($"Invalid {typeof(T).Name} {value}");
    }


    public static T ParseEnum<T>(this string value) where T : struct, IConvertible {
        var result = ParseNullableEnum<T>(value, true);
        return result ?? throw new ArgumentException($"{typeof(T)} does not contain the value '{nameof(value)}'");
    }


    public static T ParseEnum<T>(this string value, T defaultValue) where T : struct {
        if (!Enum.TryParse(value, out T result)) {
            result = defaultValue;
        }

        return result;
    }
}