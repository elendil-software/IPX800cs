using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800v4GetAnalogInputsHttpResponseParserTest
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
        var parser = new IPX800v4GetAnalogInputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
    {
        //Arrange
        var parser = new IPX800v4GetAnalogInputsHttpResponseParser();
        var expectedResponse = new List<AnalogInputResponse>
        {
            new AnalogInputResponse { Type = AnalogInputType.AnalogInput, Number = 1, Name = "Analog 1", Value = 9919 },
            new AnalogInputResponse { Type = AnalogInputType.AnalogInput, Number = 2, Name = "Analog 2", Value = 0 },
            new AnalogInputResponse { Type = AnalogInputType.AnalogInput, Number = 3, Name = "Analog 3", Value = 0 },
            new AnalogInputResponse { Type = AnalogInputType.AnalogInput, Number = 4, Name = "Analog 4", Value = 0 }
        };

        //Act
        List<AnalogInputResponse> response = parser.ParseResponse(IPX800v4JsonResponse.GetAnalogInputsJsonResponse).ToList();
            
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