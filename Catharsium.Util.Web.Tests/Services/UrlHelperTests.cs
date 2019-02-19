using Catharsium.Util.Testing;
using Catharsium.Util.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Util.Web.Tests.Services
{
    [TestClass]
    public class UrlHelperTests : TestFixture<UrlHelper>
    {
        [TestMethod]
        public void GetBaseUrl_ValidRequest_ReturnsUrlWithoutPath()
        {
            var host = "localhost";
            var port = 123;
            var path = "/test/";
            var request = Substitute.For<HttpRequest>();
            request.Host.Returns(new HostString(host, port));
            request.Path.Returns(new PathString(path));

            var actual = this.Target.GetBaseUrl(request, path);
            Assert.IsNotNull(actual);
            Assert.AreEqual($"://{host}:{port}", actual);
        }
    }
}