using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetVirtualOutputsResponseParserTest
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
        var parser = new IPX800V5GetVirtualOutputsResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V5GetVirtualOutputsResponseParser();
        var expectedResponse = new List<OutputResponse>
        {
            new() { Type = OutputType.VirtualOutput, Number = 65599, Name = "Virtual IO Test 1", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 65600, Name = "Virtual IO Test 2", State = OutputState.Active },
            new() { Type = OutputType.VirtualOutput, Number = 65601, Name = "Virtual IO Test 3", State = OutputState.Inactive },
            new() { Type = OutputType.VirtualOutput, Number = 65602, Name = "Virtual IO Test 4", State = OutputState.Active },
            new() { Type = OutputType.VirtualOutput, Number = 65603, Name = "Virtual IO 4 (TEMPO)", State = OutputState.Inactive }
        };
        
        //Act
        List<OutputResponse> response = parser.ParseResponse(IPX800V5Response.IOJson).ToList();
            
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