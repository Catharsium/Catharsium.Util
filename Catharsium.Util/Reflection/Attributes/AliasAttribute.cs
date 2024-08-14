namespace Catharsium.Util.Reflection.Attributes;

public class AliasAttribute(params string[] aliases) : Attribute
{
    public string[] Aliases { get; } = aliases;
}