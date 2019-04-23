using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Catharsium.Util.Web.Middleware.Logging
{
    public class ErrorLoggingHandler
    {
        private readonly RequestDelegate next;



        public ErrorLoggingHandler(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task Invoke(HttpContext httpContext, ILogger<ErrorLoggingHandler> logger)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Uncaught exception");
                throw;
            }
        }
    }
}