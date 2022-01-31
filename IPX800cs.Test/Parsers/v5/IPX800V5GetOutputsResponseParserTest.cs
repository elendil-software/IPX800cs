using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;
using IPX800cs.Test.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetOutputsResponseParserTest
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
        var parser = new IPX800V5GetOutputsResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V5GetOutputsResponseParser();
        var expectedResponse = new List<OutputResponse>
        {
            new() { Type = OutputType.Output, Number = 65536, Name = "[IPX]Relay cmd 1", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 65537, Name = "[IPX]Relay cmd 2", State = OutputState.Active },
            new() { Type = OutputType.Output, Number = 65538, Name = "[IPX]Relay cmd 3", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 65539, Name = "[IPX]Relay cmd 4", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 65540, Name = "[IPX]Relay cmd 5", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 65541, Name = "[IPX]Relay cmd 6", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 65542, Name = "[IPX]Relay cmd 7", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 65543, Name = "[IPX]Relay cmd 8", State = OutputState.Inactive }
        };

        //Act
        List<OutputResponse> response = parser.ParseResponse(IPX800V5Response.IOJson).ToList();
            
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