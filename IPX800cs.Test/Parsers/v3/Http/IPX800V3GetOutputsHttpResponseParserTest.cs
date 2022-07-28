using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http;

public class IPX800V3GetOutputsHttpResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V3GetOutputsHttpResponseParser();
        var jsonResponse = "{\"product\":\"IPX800_V3\",\"OUT1\":0,\"OUT2\":1,\"OUT3\":1,\"OUT4\":0,\"OUT5\":0,\"OUT6\":1,\"OUT7\":0,\"OUT8\":0,\"OUT9\":0,\"OUT10\":0,\"OUT11\":0,\"OUT12\":0,\"OUT13\":0,\"OUT14\":0,\"OUT15\":0,\"OUT16\":0,\"OUT17\":0,\"OUT18\":0,\"OUT19\":0,\"OUT20\":0,\"OUT21\":0,\"OUT22\":0,\"OUT23\":0,\"OUT24\":0,\"OUT25\":0,\"OUT26\":0,\"OUT27\":0,\"OUT28\":0,\"OUT29\":0,\"OUT30\":0,\"OUT31\":0,\"OUT32\":0}";
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
            new() { Type = OutputType.Output, Number = 32, Name = "Output 32", State = OutputState.Inactive },
        };

        //Act
        List<OutputResponse> response = parser.ParseResponse(jsonResponse).ToList();
            
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
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V3GetOutputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
}