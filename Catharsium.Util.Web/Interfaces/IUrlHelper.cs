using Microsoft.AspNetCore.Http;

namespace Catharsium.Util.Web.Services
{
    public interface IUrlHelper
    {
        string GetBaseUrl(HttpRequest request, string path);
    }
}