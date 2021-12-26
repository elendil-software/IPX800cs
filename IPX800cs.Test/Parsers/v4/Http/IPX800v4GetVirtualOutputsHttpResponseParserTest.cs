using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800v4GetVirtualOutputsHttpResponseParserTest
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
        var parser = new IPX800v4GetVirtualOutputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800v4GetVirtualOutputsHttpResponseParser();
        var expectedResponse = new List<OutputResponse>
        {
            new() { Type = OutputType.VirtualOutput, Number = 1, Name = "Virtual Output 1", State = OutputState.Active },
            new() { Type = OutputType.VirtualOutput, Number = 2, Name = "Virtual Output 2", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 3, Name = "Virtual Output 3", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 4, Name = "Virtual Output 4", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 5, Name = "Virtual Output 5", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 6, Name = "Virtual Output 6", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 7, Name = "Virtual Output 7", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 8, Name = "Virtual Output 8", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 9, Name = "Virtual Output 9", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 10, Name = "Virtual Output 10", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 11, Name = "Virtual Output 11", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 12, Name = "Virtual Output 12", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 13, Name = "Virtual Output 13", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 14, Name = "Virtual Output 14", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 15, Name = "Virtual Output 15", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 16, Name = "Virtual Output 16", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 17, Name = "Virtual Output 17", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 18, Name = "Virtual Output 18", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 19, Name = "Virtual Output 19", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 20, Name = "Virtual Output 20", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 21, Name = "Virtual Output 21", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 22, Name = "Virtual Output 22", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 23, Name = "Virtual Output 23", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 24, Name = "Virtual Output 24", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 25, Name = "Virtual Output 25", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 26, Name = "Virtual Output 26", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 27, Name = "Virtual Output 27", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 28, Name = "Virtual Output 28", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 29, Name = "Virtual Output 29", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 30, Name = "Virtual Output 30", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 31, Name = "Virtual Output 31", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 32, Name = "Virtual Output 32", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 33, Name = "Virtual Output 33", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 34, Name = "Virtual Output 34", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 35, Name = "Virtual Output 35", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 36, Name = "Virtual Output 36", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 37, Name = "Virtual Output 37", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 38, Name = "Virtual Output 38", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 39, Name = "Virtual Output 39", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 40, Name = "Virtual Output 40", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 41, Name = "Virtual Output 41", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 42, Name = "Virtual Output 42", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 43, Name = "Virtual Output 43", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 44, Name = "Virtual Output 44", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 45, Name = "Virtual Output 45", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 46, Name = "Virtual Output 46", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 47, Name = "Virtual Output 47", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 48, Name = "Virtual Output 48", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 49, Name = "Virtual Output 49", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 50, Name = "Virtual Output 50", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 51, Name = "Virtual Output 51", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 52, Name = "Virtual Output 52", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 53, Name = "Virtual Output 53", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 54, Name = "Virtual Output 54", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 55, Name = "Virtual Output 55", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 56, Name = "Virtual Output 56", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 57, Name = "Virtual Output 57", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 58, Name = "Virtual Output 58", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 59, Name = "Virtual Output 59", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 60, Name = "Virtual Output 60", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 61, Name = "Virtual Output 61", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 62, Name = "Virtual Output 62", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 63, Name = "Virtual Output 63", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 64, Name = "Virtual Output 64", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 65, Name = "Virtual Output 65", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 66, Name = "Virtual Output 66", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 67, Name = "Virtual Output 67", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 68, Name = "Virtual Output 68", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 69, Name = "Virtual Output 69", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 70, Name = "Virtual Output 70", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 71, Name = "Virtual Output 71", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 72, Name = "Virtual Output 72", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 73, Name = "Virtual Output 73", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 74, Name = "Virtual Output 74", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 75, Name = "Virtual Output 75", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 76, Name = "Virtual Output 76", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 77, Name = "Virtual Output 77", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 78, Name = "Virtual Output 78", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 79, Name = "Virtual Output 79", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 80, Name = "Virtual Output 80", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 81, Name = "Virtual Output 81", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 82, Name = "Virtual Output 82", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 83, Name = "Virtual Output 83", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 84, Name = "Virtual Output 84", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 85, Name = "Virtual Output 85", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 86, Name = "Virtual Output 86", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 87, Name = "Virtual Output 87", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 88, Name = "Virtual Output 88", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 89, Name = "Virtual Output 89", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 90, Name = "Virtual Output 90", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 91, Name = "Virtual Output 91", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 92, Name = "Virtual Output 92", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 93, Name = "Virtual Output 93", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 94, Name = "Virtual Output 94", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 95, Name = "Virtual Output 95", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 96, Name = "Virtual Output 96", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 97, Name = "Virtual Output 97", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 98, Name = "Virtual Output 98", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 99, Name = "Virtual Output 99", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 100, Name = "Virtual Output 100", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 101, Name = "Virtual Output 101", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 102, Name = "Virtual Output 102", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 103, Name = "Virtual Output 103", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 104, Name = "Virtual Output 104", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 105, Name = "Virtual Output 105", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 106, Name = "Virtual Output 106", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 107, Name = "Virtual Output 107", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 108, Name = "Virtual Output 108", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 109, Name = "Virtual Output 109", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 110, Name = "Virtual Output 110", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 111, Name = "Virtual Output 111", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 112, Name = "Virtual Output 112", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 113, Name = "Virtual Output 113", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 114, Name = "Virtual Output 114", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 115, Name = "Virtual Output 115", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 116, Name = "Virtual Output 116", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 117, Name = "Virtual Output 117", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 118, Name = "Virtual Output 118", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 119, Name = "Virtual Output 119", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 120, Name = "Virtual Output 120", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 121, Name = "Virtual Output 121", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 122, Name = "Virtual Output 122", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 123, Name = "Virtual Output 123", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 124, Name = "Virtual Output 124", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 125, Name = "Virtual Output 125", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 126, Name = "Virtual Output 126", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 127, Name = "Virtual Output 127", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 128, Name = "Virtual Output 128", State = OutputState.Inactive },
        };

        //Act
        List<OutputResponse> response = parser.ParseResponse(IPX800v4JsonResponse.GetVirtualOutputsJsonResponse).ToList();

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
}