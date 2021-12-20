using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.M2M;

public class IPX800v3GetInputsM2MResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800v3GetInputsM2MResponseParser();
        var ipxResponse = "00001101000000000000000000000000\r\n";
        var expectedResponse = new Dictionary<int, InputState>
        {
            {1, InputState.Inactive},
            {2, InputState.Inactive},
            {3, InputState.Inactive},
            {4, InputState.Inactive},
            {5, InputState.Active},
            {6, InputState.Active},
            {7, InputState.Inactive},
            {8, InputState.Active},
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
            {32, InputState.Inactive}
        };

        //Act
        var response = parser.ParseResponse(ipxResponse);

        //Assert
        Assert.Equal(expectedResponse, response);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800v3GetInputsM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
}