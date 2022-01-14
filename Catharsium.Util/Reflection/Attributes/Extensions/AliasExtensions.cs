namespace Catharsium.Util.Reflection.Attributes.Extensions;

public static class AliasExtensions
{
    public static string GetAlias<T>(this T enumType, int index, string fallback = null) where T : struct, IConvertible
    {
        var nameAlias = enumType.GetAttribute<AliasAttribute>(enumType.ToString());
        return nameAlias != null && index < nameAlias.Aliases.Length
            ? nameAlias.Aliases[index]
            : fallback;
    }
}