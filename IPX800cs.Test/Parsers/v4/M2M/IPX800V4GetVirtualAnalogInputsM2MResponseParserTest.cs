using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800V4GetVirtualAnalogInputsM2MResponseParserTest
{
    private const string HeadedResponse = "VA1=0&VA2=0&VA3=1&VA4=0&VA5=0&VA6=0&VA7=0&VA8=0&VA9=0&VA10=0&VA11=0&VA12=0&VA13=0&VA14=0&VA15=0&VA16=0&VA17=0&VA18=0&VA19=0&VA20=0&VA21=0&VA22=0&VA23=0&VA24=0&VA25=0&VA26=0&VA27=0&VA28=0&VA29=0&VA30=0&VA31=0&VA32=0";
    private const string Response = "0&0&1&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0\r\n";

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualAnalogInputsM2MResponseParser();
        var expectedResponse = new List<AnalogInputResponse>()
        {
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 1, Name = "Virtual Analog 1", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 2, Name = "Virtual Analog 2", Value = 0 },
            new() { Type = AnalogInputType.VirtualAnalogInput, Number = 3, Name = "Virtual Analog 3", Value = 1 },
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
        List<AnalogInputResponse> response = parser.ParseResponse(ipxResponse).ToList();
            
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
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualAnalogInputsM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
}