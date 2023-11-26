using System.Text;

namespace Catharsium.Util.Strings;

public static class StringCapitalizationExtensions
{
    public static string Capitalize(this string text) {
        return text.Substring(0, 1).ToUpper() + text.Substring(1);
    }


    public static string Decapitalize(this string text) {
        return text.Substring(0, 1).ToLower() + text.Substring(1);
    }


    public static string ToCamelCase(this string text, bool upper = true) {
        var result = new StringBuilder();
        var parts = text.Split(' ');

        for (var i = 0; i < parts.Length; i++) {
            var capitalize = i == 0 && upper || i > 0;
            result.Append(capitalize ? parts[i].Capitalize()
                                     : parts[i].Decapitalize());
        }

        return result.ToString();
    }
}