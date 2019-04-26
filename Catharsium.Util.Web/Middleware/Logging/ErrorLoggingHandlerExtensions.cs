using Microsoft.AspNetCore.Builder;

namespace Catharsium.Util.Web.Middleware.Logging
{
    public static class ErrorLoggingHandlerExtensions
    {
        public static IApplicationBuilder UseLoggingErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorLoggingHandler>();
        }
    }
}