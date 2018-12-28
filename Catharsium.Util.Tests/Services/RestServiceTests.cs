using System.Linq;
using System.Net;
using System.Net.Http;
using Catharsium.Util.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RestSharp;

namespace Catharsium.Util.Tests.Services
{
    [TestClass]
    public class RestServiceTests
    {
        #region Fixture

        private IRestClient RestClient { get; set; }

        private RestService Target { get; set; }


        [TestInitialize]
        public void Setup()
        {
            this.RestClient = Substitute.For<IRestClient>();
            this.Target = new RestService(this.RestClient);
        }

        #endregion

        #region PostToJsonService

        [TestMethod]
        public void PostToJsonService_ValidData_CallsServiceWith()
        {
            var response = new RestResponse {
                StatusCode = HttpStatusCode.OK,
                ResponseStatus = ResponseStatus.Completed,
                Content = "1"
            };
            this.RestClient.Execute(Arg.Any<RestRequest>()).Returns(response);
            var resource = "My resource";
            var data = "My data";

            this.Target.PostToJsonService(resource, data);
            this.RestClient.Received().Execute(Arg.Is<RestRequest>(r => IsExpectedRequest(r, resource, "application/json", data)));
        }


        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public void PostToJsonService_InvalidResponse_ThrowsException()
        {
            var response = new RestResponse {
                StatusCode = HttpStatusCode.InternalServerError,
                ResponseStatus = ResponseStatus.Error
            };
            this.RestClient.Execute(Arg.Any<RestRequest>()).Returns(response);
            var resource = "My resource";
            var data = "My data";

            this.Target.PostToJsonService(resource, data);
            this.RestClient.Received().Execute(Arg.Is<RestRequest>(r => IsExpectedRequest(r, resource, "application/json", data)));
        }

        #endregion

        #region PostToJsonServiceWithLongResponseType

        [TestMethod]
        public void PostToJsonServiceWithLongResponseType_ValidData_CallsServiceWith()
        {
            var responseContent = long.MaxValue;
            var response = new RestResponse {
                StatusCode = HttpStatusCode.OK,
                ResponseStatus = ResponseStatus.Completed,
                Content = responseContent.ToString()
            };
            this.RestClient.Execute(Arg.Any<RestRequest>()).Returns(response);
            var resource = "My resource";
            var data = "My data";

            var actual = this.Target.PostToJsonServiceWithLongResponseType(resource, data);
            Assert.AreEqual(responseContent, actual);
        }

        #endregion

        #region Support methods

        private static bool IsExpectedRequest(IRestRequest request, string resource, string bodyName, string bodyContents)
        {
            var body = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
            if (body == null) {
                return bodyContents == null;
            }

            return request.Resource == resource &&
                   request.Method == Method.POST &&
                   body.Name == bodyName &&
                   body.Value.ToString().Contains(bodyContents);
        }

        #endregion
    }
}