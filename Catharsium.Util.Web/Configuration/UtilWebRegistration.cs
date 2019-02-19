using Catharsium.Util.Web.Interfaces;
using Catharsium.Util.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Web.Configuration
{
    public static class UtilWebRegistration
    {
        public static IServiceCollection AddWebUtilities(this IServiceCollection services)
        {
            services.AddTransient<IRestService, RestService>();
            services.AddTransient<IUrlHelper, UrlHelper>();
            return services;
        }
    }
}