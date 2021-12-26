using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800v4GetInputsM2MResponseParserTest
{
    private const string HeadedResponse = "D01=0&D02=0&D03=0&D04=1&D05=1&D06=1&D07=0&D08=0&D09=0&D10=0&D11=0&D12=0&D13=0&D14=0&D15=0&D16=0&D17=0&D18=0&D19=0&D20=0&D21=0&D22=0&D23=0&D24=0&D25=0&D26=0&D27=0&D28=0&D29=0&D30=0&D31=0&D32=0&D33=0&D34=0&D35=0&D36=0&D37=0&D38=0&D39=0&D40=0&D41=0&D42=0&D43=0&D44=0&D45=0&D46=0&D47=0&D48=0&D49=0&D50=0&D51=0&D52=0&D53=0&D54=0&D55=0&D56=0";
    private const string Response = "00011100000000000000000000000000000000000000000000000000\r\n";
        
    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800v4GetInputsM2MResponseParser();
        var expectedResponse = new List<InputResponse>
        {
            new() { Type = InputType.DigitalInput, Number = 1, Name = "Input 1", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 2, Name = "Input 2", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 3, Name = "Input 3", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 4, Name = "Input 4", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 5, Name = "Input 5", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 6, Name = "Input 6", State = InputState.Active },
            new() { Type = InputType.DigitalInput, Number = 7, Name = "Input 7", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 8, Name = "Input 8", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 9, Name = "Input 9", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 10, Name = "Input 10", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 11, Name = "Input 11", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 12, Name = "Input 12", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 13, Name = "Input 13", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 14, Name = "Input 14", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 15, Name = "Input 15", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 16, Name = "Input 16", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 17, Name = "Input 17", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 18, Name = "Input 18", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 19, Name = "Input 19", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 20, Name = "Input 20", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 21, Name = "Input 21", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 22, Name = "Input 22", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 23, Name = "Input 23", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 24, Name = "Input 24", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 25, Name = "Input 25", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 26, Name = "Input 26", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 27, Name = "Input 27", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 28, Name = "Input 28", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 29, Name = "Input 29", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 30, Name = "Input 30", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 31, Name = "Input 31", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 32, Name = "Input 32", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 33, Name = "Input 33", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 34, Name = "Input 34", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 35, Name = "Input 35", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 36, Name = "Input 36", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 37, Name = "Input 37", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 38, Name = "Input 38", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 39, Name = "Input 39", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 40, Name = "Input 40", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 41, Name = "Input 41", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 42, Name = "Input 42", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 43, Name = "Input 43", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 44, Name = "Input 44", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 45, Name = "Input 45", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 46, Name = "Input 46", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 47, Name = "Input 47", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 48, Name = "Input 48", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 49, Name = "Input 49", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 50, Name = "Input 50", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 51, Name = "Input 51", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 52, Name = "Input 52", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 53, Name = "Input 53", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 54, Name = "Input 54", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 55, Name = "Input 55", State = InputState.Inactive },
            new() { Type = InputType.DigitalInput, Number = 56, Name = "Input 56", State = InputState.Inactive },
        };

        //Act
        List<InputResponse> response = parser.ParseResponse(ipxResponse).ToList();

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
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800v4GetInputsM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
}