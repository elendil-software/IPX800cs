using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800v4GetVirtualAnalogInputsHttpResponseParserTest
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
        var parser = new IPX800v4GetVirtualAnalogInputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
    {
        //Arrange
        var parser = new IPX800v4GetVirtualAnalogInputsHttpResponseParser();
        var expectedResponse = new Dictionary<int, int>
        {
            {1, 7410},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
            {7, 0},
            {8, 0},
            {9, 0},
            {10, 0},
            {11, 0},
            {12, 0},
            {13, 0},
            {14, 0},
            {15, 0},
            {16, 0},
            {17, 0},
            {18, 0},
            {19, 0},
            {20, 0},
            {21, 0},
            {22, 0},
            {23, 0},
            {24, 0},
            {25, 0},
            {26, 0},
            {27, 0},
            {28, 0},
            {29, 0},
            {30, 0},
            {31, 0},
            {32, 0}
        };

        //Act
        var response = parser.ParseResponse(IPX800v4JsonResponse.GetVirtualAnalogInputsJsonResponse);

        //Assert
        Assert.Equal(expectedResponse, response);
    }
}