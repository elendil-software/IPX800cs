using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetOutputResponseParserTest
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
        var parser = new IPX800V5GetOutputResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 2));
    }
        
    [Fact]
    public void GivenActiveOutput_ParseResponse_ReturnsActive()
    {
        //Arrange
        var parser = new IPX800V5GetOutputResponseParser();
        var jsonResponse = @"{
                              ""_id"": 65536,
                              ""name"": ""[IPX]Relay cmd 1"",
                              ""link0"": 0,
                              ""link1"": 12648448,
                              ""virtual"": false,
                              ""on"": true
                            }";

        //Act
        OutputState response = parser.ParseResponse(jsonResponse, 65536);
            
        //Assert
        Assert.Equal(OutputState.Active, response);
    }

    [Fact]
    public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
    {
        //Arrange
        var parser = new IPX800V5GetOutputResponseParser();
        var jsonResponse = @"{
                              ""_id"": 65536,
                              ""name"": ""[IPX]Relay cmd 1"",
                              ""link0"": 0,
                              ""link1"": 12648448,
                              ""virtual"": false,
                              ""on"": false
                            }";

        //Act
        OutputState response = parser.ParseResponse(jsonResponse, 65536);
            
        //Assert
        Assert.Equal(OutputState.Inactive, response);
    }
    
    [Fact]
    public void GivenActiveVirtualOutput_ParseResponse_ReturnsActive()
    {
        //Arrange
        var parser = new IPX800V5GetOutputResponseParser();
        var jsonResponse = @"{
                              ""_id"": 65599,
                              ""name"": ""Virtual IO Test 1"",
                              ""link0"": 0,
                              ""link1"": 0,
                              ""virtual"": true,
                              ""on"": true
                            }";

        //Act
        OutputState response = parser.ParseResponse(jsonResponse, 65536);
            
        //Assert
        Assert.Equal(OutputState.Active, response);
    }

    [Fact]
    public void GivenInactiveVirtualOutput_ParseResponse_ReturnsInactive()
    {
        //Arrange
        var parser = new IPX800V5GetOutputResponseParser();
        var jsonResponse = @"{
                              ""_id"": 65599,
                              ""name"": ""Virtual IO Test 1"",
                              ""link0"": 0,
                              ""link1"": 0,
                              ""virtual"": true,
                              ""on"": false
                            }";

        //Act
        OutputState response = parser.ParseResponse(jsonResponse, 65536);
            
        //Assert
        Assert.Equal(OutputState.Inactive, response);
    }
}