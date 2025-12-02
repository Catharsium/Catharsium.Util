using Catharsium.Util.Testing;
using Catharsium.Util.Web.Middleware.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace Catharsium.Util.Web.Tests.Middleware.Logging;

[TestClass]
public class ErrorLoggingHandlerTests : TestFixture<ErrorLoggingHandler>
{
    [TestMethod]
    public void Invoke_ExceptionInLifecycle_LogsError() {
        var httpContext = Substitute.For<HttpContext>();
        var logger = Substitute.For<ILogger<ErrorLoggingHandler>>();
        this.SetDependency(logger);
        this.SetDependency<RequestDelegate>(this.MyRequestDelegateWithException);

        var actual = this.Target.Invoke(httpContext);
        Assert.Throws<ApplicationException>(() => actual.GetAwaiter().GetResult());
        logger.ReceivedWithAnyArgs(1).LogError(Arg.Any<ApplicationException>(), null);
    }


    [TestMethod]
    public void Invoke_NoException_DoesNotLog() {
        var httpContext = Substitute.For<HttpContext>();
        var logger = Substitute.For<ILogger<ErrorLoggingHandler>>();
        this.SetDependency(logger);
        this.SetDependency<RequestDelegate>(this.MyHealthyRequestDelegate);

        var actual = this.Target.Invoke(httpContext);
        logger.DidNotReceiveWithAnyArgs().Log(Arg.Any<LogLevel>(), Arg.Any<Exception>(), null);
    }


    public Task MyRequestDelegateWithException(HttpContext context) {
        throw new ApplicationException();
    }


    public Task MyHealthyRequestDelegate(HttpContext context) {
        return Task.CompletedTask;
    }
}