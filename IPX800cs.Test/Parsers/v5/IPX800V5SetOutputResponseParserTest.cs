using IPX800cs.Exceptions;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5SetOutputResponseParserTest
{
    [Fact]
    public void GivenSuccess_ParseResponse_ReturnsTrue()
    {
        //Arrange
        var parser = new IPX800V5SetOutputResponseParser();
        string JsonSuccessResponse = @"{
                                            ""_id"": 65536,
                                            ""name"": ""[IPX]Relay cmd 1"",
                                            ""link0"": 0,
                                            ""link1"": 12648448,
                                            ""virtual"": false,
                                            ""on"": true
                                        }";

        //Act
        bool response = parser.ParseResponse(JsonSuccessResponse);
            
        //Assert
        Assert.True(response);
    }

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
        var parser = new IPX800V5SetOutputResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
}