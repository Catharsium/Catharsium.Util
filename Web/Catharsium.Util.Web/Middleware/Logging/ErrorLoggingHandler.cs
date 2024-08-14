using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Catharsium.Util.Web.Middleware.Logging;

public class ErrorLoggingHandler(ILogger<ErrorLoggingHandler> log, RequestDelegate next)
{
    private readonly ILogger<ErrorLoggingHandler> log = log;
    private readonly RequestDelegate next = next;


    public async Task Invoke(HttpContext httpContext) {
        try {
            await this.next(httpContext);
        }
        catch(Exception ex) {
            this.log.LogError(ex, null);
            throw;
        }
    }
}