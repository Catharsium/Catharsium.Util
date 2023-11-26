using Catharsium.Util.Reflection.Attributes;
using System;
using System.Linq;

namespace Catharsium.Util.Enums;

public static class EnumAliasHelper
{
    public static T? ParseTo<T>(this string alias, string fallback = null) where T : struct, IConvertible {
        if (alias == null) {
            throw new ArgumentNullException($"{nameof(alias)} must be supplied");
        }

        var type = typeof(T);
        if (!type.IsEnum) {
            throw new ArgumentException($"Type '{typeof(T)}' must be an enum");
        }

        T? result = null;

        foreach (var field in type.GetFields()) {
            if (Attribute.GetCustomAttribute(field, typeof(AliasAttribute)) is not AliasAttribute attribute) {
                continue;
            }

            if (attribute.Aliases.Contains(alias)) {
                return (T)field.GetValue(null);
            }

            if (fallback != null && attribute.Aliases.Contains(fallback)) {
                result = (T)field.GetValue(null);
            }
        }

        return result;
    }
}