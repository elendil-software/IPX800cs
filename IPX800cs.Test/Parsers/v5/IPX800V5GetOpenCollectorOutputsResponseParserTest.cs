using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetOpenCollectorOutputsResponseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("{}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V5GetOutputsResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V5GetOpenCollectorOutputsResponseParser();
        var expectedResponse = new List<OutputResponse>
        {
            new() { Type = OutputType.OpenCollectorOutput, Number = 65568, Name = "[IPX]Open coll.  1", State = OutputState.Inactive },
            new() { Type = OutputType.OpenCollectorOutput, Number = 65569, Name = "[IPX]Open coll.  2", State = OutputState.Active },
            new() { Type = OutputType.OpenCollectorOutput, Number = 65570, Name = "[IPX]Open coll.  3", State = OutputState.Inactive },
            new() { Type = OutputType.OpenCollectorOutput, Number = 65571, Name = "[IPX]Open coll.  4", State = OutputState.Inactive }
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