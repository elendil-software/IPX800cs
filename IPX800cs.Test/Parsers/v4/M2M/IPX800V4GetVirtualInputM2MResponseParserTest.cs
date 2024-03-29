using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800V4GetVirtualInputM2MResponseParserTest
{
    private const string HeadedResponse = "VI=0&0&0&0&0&0&0&1&1&0&0&0&0&0&0&1&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0";
    private const string Response = "00000001100000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000\r\n";

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenActiveInput_ParseResponse_ReturnsActive(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualGetInputM2MResponseParser();

        //Act
        InputState response = parser.ParseResponse(ipxResponse, 8);
            
        //Assert
        Assert.Equal(InputState.Active, response);
    }

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenInactiveInput_ParseResponse_ReturnsInactive(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualGetInputM2MResponseParser();

        //Act
        InputState response = parser.ParseResponse(ipxResponse, 7);
            
        //Assert
        Assert.Equal(InputState.Inactive, response);
    }
        
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualGetInputM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
    }
}