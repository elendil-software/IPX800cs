using System.Collections.Generic;
using System.Linq;
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
        var parser = new IPX800V3GetGetInputsM2MResponseParser();
        var ipxResponse = "00001101000000000000000000000000\r\n";
        var expectedResponse = new List<InputResponse>
        {
            new() { Type = InputType.DigitalInput, Number = 1, Name = "Input 1", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 2, Name = "Input 2", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 3, Name = "Input 3", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 4, Name = "Input 4", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 5, Name = "Input 5", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 6, Name = "Input 6", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 7, Name = "Input 7", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 8, Name = "Input 8", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 9, Name = "Input 9", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 10, Name = "Input 10", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 11, Name = "Input 11", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 12, Name = "Input 12", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 13, Name = "Input 13", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 14, Name = "Input 14", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 15, Name = "Input 15", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 16, Name = "Input 16", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 17, Name = "Input 17", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 18, Name = "Input 18", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 19, Name = "Input 19", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 20, Name = "Input 20", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 21, Name = "Input 21", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 22, Name = "Input 22", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 23, Name = "Input 23", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 24, Name = "Input 24", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 25, Name = "Input 25", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 26, Name = "Input 26", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 27, Name = "Input 27", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 28, Name = "Input 28", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 29, Name = "Input 29", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 30, Name = "Input 30", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 31, Name = "Input 31", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 32, Name = "Input 32", State = InputState.Inactive }
        };

        //Act
        List<InputResponse> response = parser.ParseResponse(ipxResponse).ToList();

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
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V3GetGetInputsM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
}