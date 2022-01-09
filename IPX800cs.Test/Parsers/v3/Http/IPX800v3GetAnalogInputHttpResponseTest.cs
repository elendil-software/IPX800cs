using IPX800cs.Exceptions;
using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http;

public class IPX800v3GetAnalogInputHttpResponseTest
{
    private const string jsonResponse = "{\"product\":\"IPX800_V3\",\"AN1\":0,\"AN2\":1,\"AN3\":0,\"AN4\":0,\"AN5\":0,\"AN6\":0,\"AN7\":0,\"AN8\":0,\"AN9\":0,\"AN10\":0,\"AN11\":0,\"AN12\":0,\"AN13\":0,\"AN14\":0,\"AN15\":0,\"AN16\":0}";
        
    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse(int input, int expectedValue)
    {
        //Arrange
        var parser = new IPX800V3GetGetAnalogInputHttpResponseParser();

        //Act
        double response = parser.ParseResponse(jsonResponse, input);
            
        //Assert
        Assert.Equal(expectedValue, response);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("{\"product\":\"IPX800_V3\",\"AN1\":0}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V3GetGetAnalogInputHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 2));
    }
}