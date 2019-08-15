using Catharsium.Util.Testing;
using Catharsium.Util.Web.Middleware.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace Catharsium.Util.Web.Tests.Middleware.Logging
{
    [TestClass]
    public class ErrorLoggingHandlerTests : TestFixture<ErrorLoggingHandler>
    {
        [TestMethod]
        public void Invoke_LogsError()
        {
            var logger = Substitute.For<ILogger<ErrorLoggingHandler>>();
            var httpContext = Substitute.For<HttpContext>();
            this.SetDependency<RequestDelegate>(this.MyRequestDelegate);

            var task = this.Target.Invoke(httpContext, logger);
            Assert.ThrowsException<ApplicationException>(() => task.GetAwaiter().GetResult());
            logger.ReceivedWithAnyArgs(1).LogError(Arg.Any<ApplicationException>(), null);
        }


        public Task MyRequestDelegate(HttpContext context)
        {
            throw new ApplicationException();
        }
    }
}