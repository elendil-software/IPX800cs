using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800v4GetInputsHttpResponseParserTest
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
        var parser = new IPX800v4GetInputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800v4GetInputsHttpResponseParser();
        var expectedResponse = new Dictionary<int, InputState>
        {
            {1, InputState.Inactive},
            {2, InputState.Inactive},
            {3, InputState.Inactive},
            {4, InputState.Active},
            {5, InputState.Active},
            {6, InputState.Active},
            {7, InputState.Inactive},
            {8, InputState.Inactive},
            {9, InputState.Inactive},
            {10, InputState.Inactive},
            {11, InputState.Inactive},
            {12, InputState.Inactive},
            {13, InputState.Inactive},
            {14, InputState.Inactive},
            {15, InputState.Inactive},
            {16, InputState.Inactive},
            {17, InputState.Inactive},
            {18, InputState.Inactive},
            {19, InputState.Inactive},
            {20, InputState.Inactive},
            {21, InputState.Inactive},
            {22, InputState.Inactive},
            {23, InputState.Inactive},
            {24, InputState.Inactive},
            {25, InputState.Inactive},
            {26, InputState.Inactive},
            {27, InputState.Inactive},
            {28, InputState.Inactive},
            {29, InputState.Inactive},
            {30, InputState.Inactive},
            {31, InputState.Inactive},
            {32, InputState.Inactive},
            {33, InputState.Inactive},
            {34, InputState.Inactive},
            {35, InputState.Inactive},
            {36, InputState.Inactive},
            {37, InputState.Inactive},
            {38, InputState.Inactive},
            {39, InputState.Inactive},
            {40, InputState.Inactive},
            {41, InputState.Inactive},
            {42, InputState.Inactive},
            {43, InputState.Inactive},
            {44, InputState.Inactive},
            {45, InputState.Inactive},
            {46, InputState.Inactive},
            {47, InputState.Inactive},
            {48, InputState.Inactive},
            {49, InputState.Inactive},
            {50, InputState.Inactive},
            {51, InputState.Inactive},
            {52, InputState.Inactive},
            {53, InputState.Inactive},
            {54, InputState.Inactive},
            {55, InputState.Inactive},
            {56, InputState.Inactive}
        };

        //Act
        var response = parser.ParseResponse(IPX800v4JsonResponse.GetInputsJsonResponse);

        //Assert
        Assert.Equal(expectedResponse, response);
    }
}