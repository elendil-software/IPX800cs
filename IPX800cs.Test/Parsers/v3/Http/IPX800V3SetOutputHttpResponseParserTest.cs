using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http;

public class IPX800V3SetOutputHttpResponseParserTest
{
    [Fact]
    public void GivenSuccess_ParseResponse_ReturnsTrue()
    {
        //Arrange
        var parser = new IPX800V3SetOutputHttpResponseParser();

        //Act
        bool response = parser.ParseResponse("OK");
            
        //Assert
        Assert.True(response);
    }
        
    [Fact]
    public void GivenError_ParseResponse_ReturnsFalse()
    {
        //Arrange
        var parser = new IPX800V3SetOutputHttpResponseParser();

        //Act
        bool response = parser.ParseResponse("");
            
        //Assert
        Assert.False(response);
    }
}