using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800V4GetVirtualOutputM2MResponseParserTest
{
    private const string HeadedResponse = "VO=1&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0";
    private const string Response = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000\r\n";

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenActiveOutput_ParseResponse_ReturnsActive(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualOutputM2MResponseParser();

        //Act
        OutputState response = parser.ParseResponse(ipxResponse, 1);
            
        //Assert
        Assert.Equal(OutputState.Active, response);
    }

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenInactiveOutput_ParseResponse_ReturnsInactive(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualOutputM2MResponseParser();

        //Act
        OutputState response = parser.ParseResponse(ipxResponse, 2);
            
        //Assert
        Assert.Equal(OutputState.Inactive, response);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualOutputM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
    }
}