using Microsoft.AspNetCore.Http;

namespace Catharsium.Util.Web
{
    public interface IUrlHelper
    {
        string GetBaseUrl(HttpRequest request, string path);
    }
}