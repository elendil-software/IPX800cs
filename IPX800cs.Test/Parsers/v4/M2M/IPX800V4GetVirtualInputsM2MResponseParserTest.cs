using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800V4GetVirtualInputsM2MResponseParserTest
{
    private const string HeadedResponse = "VI=0&0&0&0&0&0&0&1&1&0&0&0&0&0&0&1&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0";
    private const string Response = "00000001100000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000\r\n";

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualGetInputsM2MResponseParser();
        var expectedResponse = new List<InputResponse>()
        {
            new() { Type = InputType.VirtualDigitalInput, Number = 1, Name = "Virtual Input 1", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 2, Name = "Virtual Input 2", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 3, Name = "Virtual Input 3", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 4, Name = "Virtual Input 4", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 5, Name = "Virtual Input 5", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 6, Name = "Virtual Input 6", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 7, Name = "Virtual Input 7", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 8, Name = "Virtual Input 8", State = InputState.Active },
            new() { Type = InputType.VirtualDigitalInput, Number = 9, Name = "Virtual Input 9", State = InputState.Active },
            new() { Type = InputType.VirtualDigitalInput, Number = 10, Name = "Virtual Input 10", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 11, Name = "Virtual Input 11", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 12, Name = "Virtual Input 12", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 13, Name = "Virtual Input 13", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 14, Name = "Virtual Input 14", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 15, Name = "Virtual Input 15", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 16, Name = "Virtual Input 16", State = InputState.Active },
            new() { Type = InputType.VirtualDigitalInput, Number = 17, Name = "Virtual Input 17", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 18, Name = "Virtual Input 18", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 19, Name = "Virtual Input 19", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 20, Name = "Virtual Input 20", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 21, Name = "Virtual Input 21", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 22, Name = "Virtual Input 22", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 23, Name = "Virtual Input 23", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 24, Name = "Virtual Input 24", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 25, Name = "Virtual Input 25", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 26, Name = "Virtual Input 26", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 27, Name = "Virtual Input 27", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 28, Name = "Virtual Input 28", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 29, Name = "Virtual Input 29", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 30, Name = "Virtual Input 30", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 31, Name = "Virtual Input 31", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 32, Name = "Virtual Input 32", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 33, Name = "Virtual Input 33", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 34, Name = "Virtual Input 34", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 35, Name = "Virtual Input 35", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 36, Name = "Virtual Input 36", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 37, Name = "Virtual Input 37", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 38, Name = "Virtual Input 38", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 39, Name = "Virtual Input 39", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 40, Name = "Virtual Input 40", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 41, Name = "Virtual Input 41", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 42, Name = "Virtual Input 42", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 43, Name = "Virtual Input 43", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 44, Name = "Virtual Input 44", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 45, Name = "Virtual Input 45", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 46, Name = "Virtual Input 46", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 47, Name = "Virtual Input 47", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 48, Name = "Virtual Input 48", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 49, Name = "Virtual Input 49", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 50, Name = "Virtual Input 50", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 51, Name = "Virtual Input 51", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 52, Name = "Virtual Input 52", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 53, Name = "Virtual Input 53", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 54, Name = "Virtual Input 54", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 55, Name = "Virtual Input 55", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 56, Name = "Virtual Input 56", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 57, Name = "Virtual Input 57", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 58, Name = "Virtual Input 58", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 59, Name = "Virtual Input 59", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 60, Name = "Virtual Input 60", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 61, Name = "Virtual Input 61", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 62, Name = "Virtual Input 62", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 63, Name = "Virtual Input 63", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 64, Name = "Virtual Input 64", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 65, Name = "Virtual Input 65", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 66, Name = "Virtual Input 66", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 67, Name = "Virtual Input 67", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 68, Name = "Virtual Input 68", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 69, Name = "Virtual Input 69", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 70, Name = "Virtual Input 70", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 71, Name = "Virtual Input 71", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 72, Name = "Virtual Input 72", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 73, Name = "Virtual Input 73", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 74, Name = "Virtual Input 74", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 75, Name = "Virtual Input 75", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 76, Name = "Virtual Input 76", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 77, Name = "Virtual Input 77", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 78, Name = "Virtual Input 78", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 79, Name = "Virtual Input 79", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 80, Name = "Virtual Input 80", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 81, Name = "Virtual Input 81", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 82, Name = "Virtual Input 82", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 83, Name = "Virtual Input 83", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 84, Name = "Virtual Input 84", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 85, Name = "Virtual Input 85", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 86, Name = "Virtual Input 86", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 87, Name = "Virtual Input 87", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 88, Name = "Virtual Input 88", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 89, Name = "Virtual Input 89", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 90, Name = "Virtual Input 90", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 91, Name = "Virtual Input 91", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 92, Name = "Virtual Input 92", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 93, Name = "Virtual Input 93", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 94, Name = "Virtual Input 94", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 95, Name = "Virtual Input 95", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 96, Name = "Virtual Input 96", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 97, Name = "Virtual Input 97", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 98, Name = "Virtual Input 98", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 99, Name = "Virtual Input 99", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 100, Name = "Virtual Input 100", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 101, Name = "Virtual Input 101", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 102, Name = "Virtual Input 102", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 103, Name = "Virtual Input 103", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 104, Name = "Virtual Input 104", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 105, Name = "Virtual Input 105", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 106, Name = "Virtual Input 106", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 107, Name = "Virtual Input 107", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 108, Name = "Virtual Input 108", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 109, Name = "Virtual Input 109", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 110, Name = "Virtual Input 110", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 111, Name = "Virtual Input 111", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 112, Name = "Virtual Input 112", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 113, Name = "Virtual Input 113", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 114, Name = "Virtual Input 114", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 115, Name = "Virtual Input 115", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 116, Name = "Virtual Input 116", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 117, Name = "Virtual Input 117", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 118, Name = "Virtual Input 118", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 119, Name = "Virtual Input 119", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 120, Name = "Virtual Input 120", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 121, Name = "Virtual Input 121", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 122, Name = "Virtual Input 122", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 123, Name = "Virtual Input 123", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 124, Name = "Virtual Input 124", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 125, Name = "Virtual Input 125", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 126, Name = "Virtual Input 126", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 127, Name = "Virtual Input 127", State = InputState.Inactive },
            new() { Type = InputType.VirtualDigitalInput, Number = 128, Name = "Virtual Input 128", State = InputState.Inactive },
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
        var parser = new IPX800V4GetVirtualGetInputsM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
}