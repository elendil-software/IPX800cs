using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800V4GetAnalogInputsM2MResponseParserTest
{
    private const string HeadedResponse = "A1=9216&A2=0&A3=0&A4=0\r\n";
    private const string Response = "9216&0&0&0\r\n";

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenResponse_ParseResponse_ReturnsExpectedResponse(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetAnalogInputsM2MResponseParser();
        var expectedResponse = new List<AnalogInputResponse>()
        {
            new() { Type = AnalogInputType.AnalogInput, Number = 1, Name = "Analog 1", Value = 9216 },
            new() { Type = AnalogInputType.AnalogInput, Number = 2, Name = "Analog 2", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 3, Name = "Analog 3", Value = 0 },
            new() { Type = AnalogInputType.AnalogInput, Number = 4, Name = "Analog 4", Value = 0 },
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
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V4GetAnalogInputsM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
}