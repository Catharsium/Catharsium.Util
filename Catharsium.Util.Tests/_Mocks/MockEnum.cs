using Catharsium.Util.Enums;
using Catharsium.Util.Enums.Attributes;

namespace Catharsium.Util.Tests.Mocks
{
    public enum MockEnum
    {
        [Alias("1")]
        First,
        [Alias("2")]
        Second
    }
}