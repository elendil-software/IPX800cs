using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http;

public class IPX800V4GetVirtualInputHttpResponseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("{\"product\": \"IPX800_V4\",\"status\": \"Success\",\"VI1\": 0}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V4GetVirtualGetInputHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
    }
        
    [Fact]
    public void GivenActiveInput_ParseResponse_ReturnsActive()
    {
        //Arrange
        var parser = new IPX800V4GetVirtualGetInputHttpResponseParser();

        //Act
        InputState response = parser.ParseResponse(IPX800V4JsonResponse.GetVirtualInputsJsonResponse, 8);
            
        //Assert
        Assert.Equal(InputState.Active, response);
    }

        

    [Fact]
    public void GivenInactiveInput_ParseResponse_ReturnsInactive()
    {
        //Arrange
        var parser = new IPX800V4GetVirtualGetInputHttpResponseParser();

        //Act
        InputState response = parser.ParseResponse(IPX800V4JsonResponse.GetVirtualInputsJsonResponse, 2);
            
        //Assert
        Assert.Equal(InputState.Inactive, response);
    }
}