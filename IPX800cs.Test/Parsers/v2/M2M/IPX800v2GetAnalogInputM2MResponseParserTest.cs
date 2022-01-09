using IPX800cs.Exceptions;
using IPX800cs.Parsers.v2.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.M2M;

public class IPX800v2GetAnalogInputM2MResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
    {
        //Arrange
        var parser = new IPX800V2GetGetAnalogInputM2MResponseParser();
        var ipxResponse = "GetAn1=123\r\n";

        //Act
        double response = parser.ParseResponse(ipxResponse, 2);
            
        //Assert
        Assert.Equal(123, response);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V2GetGetAnalogInputM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
    }
}