using Catharsium.Util.Web.Middleware.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Web.Tests.Middleware.Logging;

[TestClass]
public class ErrorLoggingHandlerExtensionsTests
{
    [TestMethod]
    public void UseErrorLoggingHandler_RegistersDependencies() {
        var applicationBuilder = Substitute.For<IApplicationBuilder>();
        applicationBuilder.UseErrorLoggingHandler();
        applicationBuilder.Received(1).UseMiddleware<ErrorLoggingHandler>();
    }
}