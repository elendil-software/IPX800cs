using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.M2M;

public class IPX800V3GetOutputsM2MResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V3GetOutputsM2MResponseParser();
        var ipxResponse = "01100100000000000000000000000000\r\n";
        var expectedResponse = new List<OutputResponse>
        {
            new() { Type = OutputType.Output, Number = 1, Name = "Output 1", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 2, Name = "Output 2", State = OutputState.Active },
            new() { Type = OutputType.Output, Number = 3, Name = "Output 3", State = OutputState.Active },
            new() { Type = OutputType.Output, Number = 4, Name = "Output 4", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 5, Name = "Output 5", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 6, Name = "Output 6", State = OutputState.Active },
            new() { Type = OutputType.Output, Number = 7, Name = "Output 7", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 8, Name = "Output 8", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 9, Name = "Output 9", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 10, Name = "Output 10", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 11, Name = "Output 11", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 12, Name = "Output 12", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 13, Name = "Output 13", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 14, Name = "Output 14", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 15, Name = "Output 15", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 16, Name = "Output 16", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 17, Name = "Output 17", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 18, Name = "Output 18", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 19, Name = "Output 19", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 20, Name = "Output 20", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 21, Name = "Output 21", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 22, Name = "Output 22", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 23, Name = "Output 23", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 24, Name = "Output 24", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 25, Name = "Output 25", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 26, Name = "Output 26", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 27, Name = "Output 27", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 28, Name = "Output 28", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 29, Name = "Output 29", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 30, Name = "Output 30", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 31, Name = "Output 31", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 32, Name = "Output 32", State = OutputState.Inactive }
        };

        //Act
        List<OutputResponse> response = parser.ParseResponse(ipxResponse).ToList();
            
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
        var parser = new IPX800V3GetOutputsM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
}