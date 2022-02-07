using System.Net.Http;
using IPX800cs.Commands;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Senders.HttpWebRequestBuilder;

public class HttpWebRequestBuilderTest
{
    [Theory]
    [InlineData("http://192.168.1.2", 8080, "/api/xdevices.json?Get=R", "/api/xdevices.json?Get=R")]
    [InlineData("http://192.168.1.2", 8080, "api/xdevices.json?Get=R", "/api/xdevices.json?Get=R")]
    [InlineData("http://192.168.1.2", 8080, "api/xdevices.json", "/api/xdevices.json")]
    public void Build_Returns_ExpectedQuery(string host, int port, string command, string expectedRequest)
    {
        //Arrange
        var context = new Context(host, port, IPX800Protocol.Http, IPX800Version.V4);
        var httpWebRequestBuilder = new IPX800cs.Commands.Senders.HttpWebRequestBuilder.HttpRequestMessageBuilderBase(context);

        //Act
        HttpRequestMessage request = httpWebRequestBuilder.Build(Command.CreateGet(command));

        //Assert
        Assert.Equal(expectedRequest, request.RequestUri.ToString());
    }
}