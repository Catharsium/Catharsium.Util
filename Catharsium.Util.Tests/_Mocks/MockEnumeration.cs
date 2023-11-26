using Catharsium.Util.Reflection.Attributes;

namespace Catharsium.Util.Tests._Mocks;

public enum MockEnumeration
{
    [Alias("1")]
    First,
    [Alias("2")]
    Second,
    [Alias("My alias")]
    WithAlias,
    WithoutAlias
}