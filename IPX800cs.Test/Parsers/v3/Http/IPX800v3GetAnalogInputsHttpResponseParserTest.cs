using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http;

public class IPX800v3GetAnalogInputsHttpResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800v3GetAnalogInputsHttpResponseParser();
        var jsonResponse = "{\"product\":\"IPX800_V3\",\"AN1\":0,\"AN2\":1,\"AN3\":0,\"AN4\":0,\"AN5\":0,\"AN6\":0,\"AN7\":0,\"AN8\":0,\"AN9\":0,\"AN10\":0,\"AN11\":0,\"AN12\":0,\"AN13\":0,\"AN14\":0,\"AN15\":0,\"AN16\":0}";
        var expectedResponse = new List<AnalogInputResponse>
        {
            new() { Type = AnalogInputType.AnalogInput, Number = 1, Name = "Analog 1", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 2, Name = "Analog 2", Value = 1 },
            new() { Type = AnalogInputType.AnalogInput, Number = 3, Name = "Analog 3", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 4, Name = "Analog 4", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 5, Name = "Analog 5", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 6, Name = "Analog 6", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 7, Name = "Analog 7", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 8, Name = "Analog 8", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 9, Name = "Analog 9", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 10, Name = "Analog 10", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 11, Name = "Analog 11", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 12, Name = "Analog 12", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 13, Name = "Analog 13", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 14, Name = "Analog 14", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 15, Name = "Analog 15", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 16, Name = "Analog 16", Value = 0 }
        };

        //Act
        List<AnalogInputResponse> response = parser.ParseResponse(jsonResponse).ToList();
            
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
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800v3GetAnalogInputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
}