using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800v4GetAnalogInputsHttpResponseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800v4GetAnalogInputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
    {
        //Arrange
        var parser = new IPX800v4GetAnalogInputsHttpResponseParser();
        var expectedResponse = new Dictionary<int, int>
        {
            {1, 9919},
            {2, 0},
            {3, 0},
            {4, 0}
        };

        //Act
        var response = parser.ParseResponse(IPX800v4JsonResponse.GetAnalogInputsJsonResponse);
            
        //Assert
        Assert.Equal(expectedResponse, response);
    }
}