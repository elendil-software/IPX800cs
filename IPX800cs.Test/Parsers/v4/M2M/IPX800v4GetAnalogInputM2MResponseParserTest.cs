using IPX800cs.Exceptions;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800v4GetAnalogInputM2MResponseParserTest
{
    private const string HeadedResponse = "A1=9232&A2=0&A3=0&A4=0\r\n";
    private const string Response = "9216&0&0&0\r\n";
        
    [Theory]
    [InlineData(HeadedResponse, 9232)]
    [InlineData(Response, 9216)]
    public void GivenResponse_ParseResponse_ReturnsExpectedResponse(string ipxResponse, double expectedResult)
    {
        //Arrange
        var parser = new IPX800V4GetGetAnalogInputM2MResponseParser();

        //Act
        double result = parser.ParseResponse(ipxResponse, 1);
            
        //Assert
        Assert.Equal(expectedResult, result);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V4GetGetAnalogInputM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
    }
}