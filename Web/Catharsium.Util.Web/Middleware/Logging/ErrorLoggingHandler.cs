using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Catharsium.Util.Web.Middleware.Logging;

public class ErrorLoggingHandler
{
    private readonly ILogger<ErrorLoggingHandler> log;
    private readonly RequestDelegate next;



    public ErrorLoggingHandler(ILogger<ErrorLoggingHandler> log, RequestDelegate next)
    {
        this.log = log;
        this.next = next;
    }


    public async Task Invoke(HttpContext httpContext)
    {
        try {
            await this.next(httpContext);
        }
        catch (Exception ex) {
            this.log.LogError(ex, null);
            throw;
        }
    }
}