using System;
using System.Linq;

namespace Catharsium.Util.Enums
{
    public static class CodeHelper
    {
        public static T? ParseTo<T>(this string code, string fallback = null) where T : struct, IConvertible
        {
            if (code == null) throw new ArgumentNullException($"{nameof(code)} must be supplied");
            var type = typeof(T);
            if (!type.IsEnum) throw new ArgumentException($"Type '{typeof(T)}' must be an enum");

            T? result = null;

            foreach (var field in type.GetFields()) {
                if (!(Attribute.GetCustomAttribute(field, typeof(CodeAttribute)) is CodeAttribute attribute)) {
                    continue;
                }

                if (attribute.Codes.Contains(code)) {
                    return (T)field.GetValue(null);
                }

                if (fallback != null && attribute.Codes.Contains(fallback)) {
                    result = (T)field.GetValue(null);
                }
            }

            return result;
        }
    }
}