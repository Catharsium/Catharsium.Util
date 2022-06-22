using System.Collections.Generic;
using System.Linq;

namespace Catharsium.Util.Web.Extensions;

public static class UrlExtensions
{
    public static string AddQuery(this string url, Dictionary<string, string> variables)
    {
        return $"{url}?{string.Join("&", variables.Select(v => $"{v.Key}={v.Value}"))}";
    }
}