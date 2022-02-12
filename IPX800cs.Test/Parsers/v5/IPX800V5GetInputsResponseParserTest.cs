using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetInputsResponseParserTest
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
        var parser = new IPX800V5GetInputsResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V5GetInputsResponseParser();
        var expectedResponse = new List<InputResponse>
        {
            new() { Type = InputType.DigitalInput, Number = 65552, Name = "[IPX]Digital input 1", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 65553, Name = "[IPX]Digital input 2", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 65554, Name = "[IPX]Digital input 3", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 65555, Name = "[IPX]Digital input 4", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 65556, Name = "[IPX]Digital input 5", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 65557, Name = "[IPX]Digital input 6", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 65558, Name = "[IPX]Digital input 7", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 65559, Name = "[IPX]Digital input 8", State = InputState.Inactive }
        };

        //Act
        List<InputResponse> response = parser.ParseResponse(IPX800V5Response.IOJson).ToList();

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
}