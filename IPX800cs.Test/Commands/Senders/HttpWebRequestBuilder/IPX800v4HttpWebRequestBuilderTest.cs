using IPX800cs.Commands;
using IPX800cs.Commands.Senders.HttpWebRequestBuilder;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Senders.HttpWebRequestBuilder;

public class IPX800V4HttpWebRequestBuilderTest
{
    [Fact]
    public void WhenApiKeyIsSet_GeneratedUri_ContainsKeyParameter()
    {
        //Arrange
        var context = new Context("http://192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4, "user", "apiKey");
        var ipx800V4HttpWebRequestBuilder = new IPX800v4HttpWebRequestBuilder(context, "key");

        //Act
        var request = ipx800V4HttpWebRequestBuilder.Build(Command.CreateGet("/api/xdevices.json?Get=R"));

        //Assert
        Assert.Equal("?Get=R&key=apiKey", request.RequestUri.Query);
    }


    [Fact]
    public void WhenApiKeyIsNotSet_GeneratedUri_NotContainsKeyParameter()
    {
        //Arrange
        var context = new Context("http://192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
        var ipx800V4HttpWebRequestBuilder = new IPX800v4HttpWebRequestBuilder(context, "key");

        //Act
        var request = ipx800V4HttpWebRequestBuilder.Build(Command.CreateGet("/api/xdevices.json?Get=R"));

        //Assert
        Assert.Equal("?Get=R", request.RequestUri.Query);
    }
}