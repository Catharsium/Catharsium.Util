using Microsoft.AspNetCore.Http;
namespace Catharsium.Util.Web.Interfaces;

public interface IUrlHelper
{
    string GetBaseUrl(HttpRequest request, string path);
}