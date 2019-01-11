using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace Catharsium.Util.Web
{
    public class UrlHelper : IUrlHelper
    {
        public string GetBaseUrl(HttpRequest request, string path)
        {
            var url = request.GetEncodedUrl();
            return url.Replace(path, string.Empty);
        }
    }
}