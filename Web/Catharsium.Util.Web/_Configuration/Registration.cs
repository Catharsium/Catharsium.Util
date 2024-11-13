using Catharsium.Util.Configuration.Extensions;
using Catharsium.Util.Web.Interfaces;
using Catharsium.Util.Web.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Catharsium.Util.Web._Configuration;

public static class Registration
{
    public static IServiceCollection AddWebUtilities(this IServiceCollection services, IConfiguration config) {
        var configuration = config.Load<WebUtilSettings>();
        services.AddSingleton<WebUtilSettings, WebUtilSettings>(_ => configuration);

        //services.TryAddTransient<IRestService, RestService>();
        services.TryAddTransient<IUrlHelper, UrlHelper>();

        return services;
    }
}