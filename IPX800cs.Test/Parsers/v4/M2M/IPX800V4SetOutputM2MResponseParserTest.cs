using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800V4SetOutputM2MResponseParserTest
{
    [Fact]
    public void GivenSuccess_ParseResponse_ReturnsTrue()
    {
        //Arrange
        var parser = new IPX800V4SetOutputM2MResponseParser();
        var ipxResponse = "Success\r\n";

        //Act
        bool response = parser.ParseResponse(ipxResponse);
            
        //Assert
        Assert.True(response);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("Invalid response\r\n")]
    public void GivenError_ParseResponse_ReturnsFalse(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V4SetOutputM2MResponseParser();

        //Act
        bool response = parser.ParseResponse(invalidResponse);
            
        //Assert
        Assert.False(response);
    }
}