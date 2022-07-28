using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800V4GetOutputsHttpResponseParserTest
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
        var parser = new IPX800V4GetOutputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V4GetOutputsHttpResponseParser();
        var expectedResponse = new List<OutputResponse>
        {
            new() { Type = OutputType.Output, Number = 1, Name = "Output 1", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 2, Name = "Output 2", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 3, Name = "Output 3", State = OutputState.Active },
            new() { Type = OutputType.Output, Number = 4, Name = "Output 4", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 5, Name = "Output 5", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 6, Name = "Output 6", State = OutputState.Active },
            new() { Type = OutputType.Output, Number = 7, Name = "Output 7", State = OutputState.Active },
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
            new() { Type = OutputType.Output, Number = 32, Name = "Output 32", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 33, Name = "Output 33", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 34, Name = "Output 34", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 35, Name = "Output 35", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 36, Name = "Output 36", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 37, Name = "Output 37", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 38, Name = "Output 38", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 39, Name = "Output 39", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 40, Name = "Output 40", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 41, Name = "Output 41", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 42, Name = "Output 42", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 43, Name = "Output 43", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 44, Name = "Output 44", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 45, Name = "Output 45", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 46, Name = "Output 46", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 47, Name = "Output 47", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 48, Name = "Output 48", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 49, Name = "Output 49", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 50, Name = "Output 50", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 51, Name = "Output 51", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 52, Name = "Output 52", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 53, Name = "Output 53", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 54, Name = "Output 54", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 55, Name = "Output 55", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 56, Name = "Output 56", State = OutputState.Inactive },
        };

        //Act
        List<OutputResponse> response = parser.ParseResponse(IPX800V4JsonResponse.GetOutputsJsonResponse).ToList();
            
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