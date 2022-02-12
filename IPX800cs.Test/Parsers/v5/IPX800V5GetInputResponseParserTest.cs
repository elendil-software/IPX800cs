using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetInputResponseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("{\"Status\": \"Invalid ID\"}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V5GetInputResponseParser();
        
        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 65552));
    }
        
    [Fact]
    public void GivenActiveInput_ParseResponse_ReturnsActive()
    {
        //Arrange
        var parser = new IPX800V5GetInputResponseParser();
        var jsonResponse = @"{
                                  ""_id"": 65552,
                                  ""name"": ""[IPX]Digital input 1"",
                                  ""link0"": 12582912,
                                  ""link1"": 0,
                                  ""virtual"": false,
                                  ""on"": true
                                }";

        //Act
        InputState response = parser.ParseResponse(jsonResponse, 65552);
            
        //Assert
        Assert.Equal(InputState.Active, response);
    }

    [Fact]
    public void GivenInactiveInput_ParseResponse_ReturnsInactive()
    {
        //Arrange
        var parser = new IPX800V5GetInputResponseParser();
        var jsonResponse = @"{
                                  ""_id"": 65552,
                                  ""name"": ""[IPX]Digital input 1"",
                                  ""link0"": 12582912,
                                  ""link1"": 0,
                                  ""virtual"": false,
                                  ""on"": false
                                }";

        //Act
        InputState response = parser.ParseResponse(jsonResponse, 65552);
            
        //Assert
        Assert.Equal(InputState.Inactive, response);
    }
}