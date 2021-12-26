using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800v4GetVirtualAnalogInputsHttpResponseParserTest
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
        var parser = new IPX800v4GetVirtualAnalogInputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
    {
        //Arrange
        var parser = new IPX800v4GetVirtualAnalogInputsHttpResponseParser();
        var expectedResponse = new List<AnalogInputResponse>()
        {
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 1, Name = "Virtual Analog 1", Value = 7410 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 2, Name = "Virtual Analog 2", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 3, Name = "Virtual Analog 3", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 4, Name = "Virtual Analog 4", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 5, Name = "Virtual Analog 5", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 6, Name = "Virtual Analog 6", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 7, Name = "Virtual Analog 7", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 8, Name = "Virtual Analog 8", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 9, Name = "Virtual Analog 9", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 10, Name = "Virtual Analog 10", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 11, Name = "Virtual Analog 11", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 12, Name = "Virtual Analog 12", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 13, Name = "Virtual Analog 13", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 14, Name = "Virtual Analog 14", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 15, Name = "Virtual Analog 15", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 16, Name = "Virtual Analog 16", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 17, Name = "Virtual Analog 17", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 18, Name = "Virtual Analog 18", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 19, Name = "Virtual Analog 19", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 20, Name = "Virtual Analog 20", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 21, Name = "Virtual Analog 21", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 22, Name = "Virtual Analog 22", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 23, Name = "Virtual Analog 23", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 24, Name = "Virtual Analog 24", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 25, Name = "Virtual Analog 25", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 26, Name = "Virtual Analog 26", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 27, Name = "Virtual Analog 27", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 28, Name = "Virtual Analog 28", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 29, Name = "Virtual Analog 29", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 30, Name = "Virtual Analog 30", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 31, Name = "Virtual Analog 31", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 32, Name = "Virtual Analog 32", Value = 0 },
        };

        //Act
        List<AnalogInputResponse> response = parser.ParseResponse(IPX800v4JsonResponse.GetVirtualAnalogInputsJsonResponse).ToList();

        //Assert
        Assert.Equal(expectedResponse.Count, response.Count);
        for (int i = 0; i < response.Count; i++)
        {
            Assert.Equal(expectedResponse[i].Name, response[i].Name);
            Assert.Equal(expectedResponse[i].Value, response[i].Value);
            Assert.Equal(expectedResponse[i].Number, response[i].Number);
            Assert.Equal(expectedResponse[i].Type, response[i].Type);
        };
    }
}