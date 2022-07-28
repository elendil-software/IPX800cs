using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800V4GetVirtualOutputHttpResponseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("{\"product\": \"IPX800_V4\",\"status\": \"Success\",\"VO1\": 0}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualOutputHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
    }
        
    [Fact]
    public void GivenActiveOutput_ParseResponse_ReturnsActive()
    {
        //Arrange
        var parser = new IPX800V4GetVirtualOutputHttpResponseParser();

        //Act
        OutputState response = parser.ParseResponse(IPX800V4JsonResponse.GetVirtualOutputsJsonResponse, 1);
            
        //Assert
        Assert.Equal(OutputState.Active, response);
    }

    [Fact]
    public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
    {
        //Arrange
        var parser = new IPX800V4GetVirtualOutputHttpResponseParser();

        //Act
        OutputState response = parser.ParseResponse(IPX800V4JsonResponse.GetVirtualOutputsJsonResponse, 2);
            
        //Assert
        Assert.Equal(OutputState.Inactive, response);
    }
}