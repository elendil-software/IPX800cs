using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http;

public class IPX800v2GetInputsHttpResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800v2GetInputsHttpResponseParser();
        var xmlResponse = IPX800v2HttpResponse.Xml;
        var expectedResponse = new List<InputResponse>
        {
            new() { Type = InputType.DigitalInput, Number = 4, Name = "Input 4", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 3, Name = "Input 3", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 2, Name = "Input 2", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 1, Name = "Input 1", State = InputState.Active },
        };

        //Act
        List<InputResponse> response = parser.ParseResponse(xmlResponse).ToList();

        //Assert
        Assert.Equal(expectedResponse.Count, response.Count);
        for (int i = 0; i < response.Count; i++)
        {
            Assert.Equal(expectedResponse[i].Name, response[i].Name);
            Assert.Equal(expectedResponse[i].State, response[i].State);
            Assert.Equal(expectedResponse[i].Number, response[i].Number);
            Assert.Equal(expectedResponse[i].Type, response[i].Type);
        }
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
        var parser = new IPX800v2GetInputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
}