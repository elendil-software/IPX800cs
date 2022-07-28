using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http;

public class IPX800V2GetOutputsHttpResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V2GetOutputsHttpResponseParser();
        var xmlResponse = IPX800V2HttpResponse.Xml;
        var expectedResponse = new List<OutputResponse>
        {
            new() { Type = OutputType.Output, Number = 1, Name = "Output 1", State = OutputState.Active },
            new() { Type = OutputType.Output, Number = 2, Name = "Output 2", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 3, Name = "Output 3", State = OutputState.Active },
            new() { Type = OutputType.Output, Number = 4, Name = "Output 4", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 5, Name = "Output 5", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 6, Name = "Output 6", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 7, Name = "Output 7", State = OutputState.Inactive },
            new() { Type = OutputType.Output, Number = 8, Name = "Output 8", State = OutputState.Inactive },
        };

        //Act
        List<OutputResponse> response = parser.ParseResponse(xmlResponse).ToList();

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
    [InlineData("<response><led0>??</led0><led1>??</led1><led2>??</led2><led3>??</led3></response>")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V2GetOutputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
}