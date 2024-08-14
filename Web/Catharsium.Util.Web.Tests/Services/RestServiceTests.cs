using Catharsium.Util.Testing;
using Catharsium.Util.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RestSharp;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Catharsium.Util.Web.Tests.Services;

[Ignore]
[TestClass]
public class RestServiceTests : TestFixture<RestService>
{
    #region Fixture

    [TestInitialize]
    public void Initialize() {
        var restClient = Substitute.For<RestClient>();
        this.SetDependency(restClient);
    }

    #endregion

    #region PostToJsonService

    [TestMethod]
    public void PostToJsonService_ValidData_CallsServiceWith() {
        var response = new RestResponse {
            StatusCode = HttpStatusCode.OK,
            ResponseStatus = ResponseStatus.Completed,
            Content = "My content"
        };
        this.GetDependency<RestClient>().Execute(Arg.Any<RestRequest>()).Returns(response);
        var resource = "My resource";
        var data = "My data";

        var actual = this.Target.PostToJsonService(resource, data);
        Assert.AreEqual(response.Content, actual);
    }


    [TestMethod]
    [ExpectedException(typeof(HttpRequestException))]
    public void PostToJsonService_InvalidResponse_ThrowsException() {
        var response = new RestResponse {
            StatusCode = HttpStatusCode.InternalServerError,
            ResponseStatus = ResponseStatus.Error
        };
        this.GetDependency<RestClient>().Execute(Arg.Any<RestRequest>()).Returns(response);
        var resource = "My resource";
        var data = "My data";

        this.Target.PostToJsonService(resource, data);
        this.GetDependency<RestClient>().Received().Execute(Arg.Is<RestRequest>(r => IsExpectedRequest(r, resource, "application/json", data)));
    }

    #endregion

    #region PostToJsonServiceWithLongResponseType

    [TestMethod]
    public void PostToJsonServiceWithLongResponseType_ValidData_CallsServiceWith() {
        var responseContent = long.MaxValue;
        var response = new RestResponse {
            StatusCode = HttpStatusCode.OK,
            ResponseStatus = ResponseStatus.Completed,
            Content = responseContent.ToString(),
        };
        this.GetDependency<RestClient>().Execute(Arg.Any<RestRequest>()).Returns(response);
        var resource = "My resource";
        var data = "My data";

        var actual = this.Target.PostToJsonServiceWithLongResponseType(resource, data);
        Assert.AreEqual(responseContent, actual);
    }

    #endregion

    #region Support methods

    private static bool IsExpectedRequest(RestRequest request, string resource, string bodyName, string bodyContents) {
        var body = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
        return body == null
            ? bodyContents == null
            : request.Resource == resource &&
              request.Method == Method.Post &&
              body.Name == bodyName &&
              body.Value.ToString().Contains(bodyContents);
    }

    #endregion
}