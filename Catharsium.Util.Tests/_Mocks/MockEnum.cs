using Catharsium.Util.Attributes;

namespace Catharsium.Util.Tests._Mocks
{
    public enum MockEnum
    {
        [Alias("1")]
        First,
        [Alias("2")]
        Second,
        [Alias("My alias")]
        WithAlias,
        WithoutAlias
    }
}