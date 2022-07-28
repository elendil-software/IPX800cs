using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http;

public class IPX800V2GetOutputHttpResponseParserTest
{
    [Fact]
    public void GivenActiveOutput_ParseResponse_ReturnsActive()
    {
        //Arrange
        var parser = new IPX800V2GetOutputHttpResponseParser();

        //Act
        OutputState response = parser.ParseResponse(IPX800V2HttpResponse.Xml, 3);
            
        //Assert
        Assert.Equal(OutputState.Active, response);
    }

    [Fact]
    public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
    {
        //Arrange
        var parser = new IPX800V2GetOutputHttpResponseParser();

        //Act
        OutputState response = parser.ParseResponse(IPX800V2HttpResponse.Xml, 2);
            
        //Assert
        Assert.Equal(OutputState.Inactive, response);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("<response><led0>??</led0><led1>??</led1><led2>??</led2><led3>??</led3></response>")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V2GetOutputHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 1));
    }
}