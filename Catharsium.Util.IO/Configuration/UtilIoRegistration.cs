using Catharsium.Util.IO.Interfaces;
using Catharsium.Util.IO.Wrappers;
using Microsoft.Extensions.DependencyInjection;

namespace Catharsium.Util.IO.Configuration
{
    public static class UtilIoRegistration
    {
        public static IServiceCollection AddIoUtilities(this IServiceCollection services)
        {
            services.AddTransient<IFileFactory, FileFactory>();
            return services;
        }
    }
}