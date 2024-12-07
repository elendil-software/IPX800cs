using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetAnalogInputsResponseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("{}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V5GetAnalogInputsResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
    {
        //Arrange
        var parser = new IPX800V5GetAnalogInputsResponseParser();
        var expectedResponse = new List<AnalogInputResponse>
        {
            new AnalogInputResponse { Type = AnalogInputType.AnalogInput, Number = 262144, Name = "[IPX]Analog input 1", Value = 9919.5 },
            new AnalogInputResponse { Type = AnalogInputType.AnalogInput, Number = 262145, Name = "[IPX]Analog input 2", Value = 0 },
            new AnalogInputResponse { Type = AnalogInputType.AnalogInput, Number = 262146, Name = "[IPX]Analog input 3", Value = 0 },
            new AnalogInputResponse { Type = AnalogInputType.AnalogInput, Number = 262147, Name = "[IPX]Analog input 4", Value = 0 }
        };

        //Act
        List<AnalogInputResponse> response = parser.ParseResponse(IPX800V5Response.AnaJson).ToList();
            
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
}