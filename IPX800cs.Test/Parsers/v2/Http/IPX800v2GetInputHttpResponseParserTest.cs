using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http;

public class IPX800v2GetInputHttpResponseParserTest
{
    [Theory]
    [InlineData(1, InputState.Active)]
    [InlineData(2, InputState.Active)]
    [InlineData(3, InputState.Inactive)]
    [InlineData(4, InputState.Inactive)]
    public void ParseResponse_ReturnsExpectedState(int input, InputState expectedState)
    {
        //Arrange
        var parser = new IPX800v2GetInputHttpResponseParser();

        //Act
        InputState response = parser.ParseResponse(IPX800v2HttpResponse.Xml, input);
            
        //Assert
        Assert.Equal(expectedState, response);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("<response><btn0>??</btn0><btn1>??</btn1><btn2>??</btn2><btn3>??</btn3></response>")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800v2GetInputHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 1));
    }
}