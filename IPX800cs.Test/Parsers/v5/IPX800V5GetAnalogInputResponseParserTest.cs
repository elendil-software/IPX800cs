using IPX800cs.Exceptions;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetAnalogInputResponseParserTest
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
        var parser = new IPX800V5GetAnalogInputResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 2));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
    {
        //Arrange
        var parser = new IPX800V5GetAnalogInputResponseParser();
        var jsonResponse = @"{
                              ""_id"": 262144,
                              ""link0"": 12713984,
                              ""link1"": 0,
                              ""name"": ""[IPX]Analog input 1"",
                              ""unit"": ""RAW"",
                              ""nbdecimal"": 0,
                              ""virtual"": false,
                              ""value"": 9919
                            }";

        //Act
        double response = parser.ParseResponse(jsonResponse, 262144);
            
        //Assert
        Assert.Equal(9919, response);
    }
}