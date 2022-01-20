using System.Linq;
using System.Net;
using IPX800cs.Commands;
using IPX800cs.Commands.Senders.HttpWebRequestBuilder;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Senders.HttpWebRequestBuilder;

public class AuthorizedHttpWebRequestBuilderTest
{
    [Theory]
    [InlineData("http://192.168.1.2", 8080, "/api/xdevices.json?Get=R", "http://192.168.1.2:8080/api/xdevices.json?Get=R")]
    [InlineData("http://192.168.1.2", 8080, "api/xdevices.json?Get=R", "http://192.168.1.2:8080/api/xdevices.json?Get=R")]
    [InlineData("http://192.168.1.2", 8080, "api/xdevices.json", "http://192.168.1.2:8080/api/xdevices.json")]
    public void Build_Returns_ExpectedQueryAndContainsAuthorizationHeader(string host, int port, string command, string expectedRequest)
    {
        //Arrange
        var context = new Context(host, port, IPX800Protocol.Http, IPX800Version.V3, "USER", "PASS");
        var defaultHttpWebRequestBuilder = new AuthorizedHttpWebRequestBuilder(context);

        //Act
        WebRequest request = defaultHttpWebRequestBuilder.Build(Command.CreateGet(command));

        //Assert
        Assert.Equal(expectedRequest, request.RequestUri.ToString());
        Assert.Equal(1, request.Headers.AllKeys.Count(k => k == "Authorization"));
    }
}