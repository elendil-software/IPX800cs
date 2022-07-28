using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http;

public class IPX800V2GetAnalogInputsHttpResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V2GetAnalogInputsHttpResponseParser();
        var xmlResponse = IPX800V2HttpResponse.Xml;
        var expectedResponse = new List<AnalogInputResponse>
        {
            new() { Type = AnalogInputType.AnalogInput, Number = 1, Name = "Analog 1", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 2, Name = "Analog 2", Value = 1 },
        };

        //Act
        List<AnalogInputResponse> response = parser.ParseResponse(xmlResponse).ToList();

        //Assert
        Assert.Equal(expectedResponse.Count, response.Count);
        for (int i = 0; i < response.Count; i++)
        {
            Assert.Equal(expectedResponse[i].Name, response[i].Name);
            Assert.Equal(expectedResponse[i].Value, response[i].Value);
            Assert.Equal(expectedResponse[i].Number, response[i].Number);
            Assert.Equal(expectedResponse[i].Type, response[i].Type);
        }
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("<response><an0>??</an0><an1>??</an1></response>")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V2GetAnalogInputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
}