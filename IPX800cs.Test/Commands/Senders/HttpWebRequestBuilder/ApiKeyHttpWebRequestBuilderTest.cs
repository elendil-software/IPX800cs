using System.Net;
using IPX800cs.Commands;
using IPX800cs.Commands.Senders.HttpWebRequestBuilder;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Senders.HttpWebRequestBuilder;

public class ApiKeyHttpWebRequestBuilderTest
{
    [Theory]
    [InlineData("http://192.168.1.2", 8080, "/api/devices?Get=R", "http://192.168.1.2:8080/api/devices?Get=R&key=apiKey")]
    [InlineData("http://192.168.1.2", 8080, "api/devices?Get=R", "http://192.168.1.2:8080/api/devices?Get=R&key=apiKey")]
    [InlineData("http://192.168.1.2", 8080, "/api/devices", "http://192.168.1.2:8080/api/devices?key=apiKey")]
    [InlineData("http://192.168.1.2", 8080, "api/devices", "http://192.168.1.2:8080/api/devices?key=apiKey")]
    public void Build_Returns_ExpectedQueryAndContainsAuthorizationHeader(string host, int port, string command, string expectedRequest)
    {
        //Arrange
        var context = new Context(host, port, IPX800Protocol.Http, IPX800Version.V3, "", "apiKey");
        var defaultHttpWebRequestBuilder = new ApiKeyHttpWebRequestBuilder(context, "key");

        //Act
        WebRequest request = defaultHttpWebRequestBuilder.Build(Command.CreateGet(command));

        //Assert
        Assert.Equal(expectedRequest, request.RequestUri.ToString());
        Assert.Equal("GET", request.Method);
    }
}