using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Web.Interfaces;
using Catharsium.Util.Web.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.Web._Configuration
{
    public static class WebUtilRegistration
    {
        public static IServiceCollection AddWebUtilities(this IServiceCollection services, IConfiguration config)
        {
            var configuration = config.Load<WebUtilConfiguration>();
            services.AddSingleton(configuration);

            services.AddTransient<IRestService, RestService>();
            services.AddTransient<IUrlHelper, UrlHelper>();

            return services;
        }
    }
}