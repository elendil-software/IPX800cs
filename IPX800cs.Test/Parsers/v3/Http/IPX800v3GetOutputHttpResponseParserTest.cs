using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http;

public class IPX800v3GetOutputHttpResponseParserTest
{
    private const string jsonResponse = "{\"product\":\"IPX800_V3\",\"OUT1\":0,\"OUT2\":1,\"OUT3\":1,\"OUT4\":0,\"OUT5\":0,\"OUT6\":1,\"OUT7\":0,\"OUT8\":0,\"OUT9\":0,\"OUT10\":0,\"OUT11\":0,\"OUT12\":0,\"OUT13\":0,\"OUT14\":0,\"OUT15\":0,\"OUT16\":0,\"OUT17\":0,\"OUT18\":0,\"OUT19\":0,\"OUT20\":0,\"OUT21\":0,\"OUT22\":0,\"OUT23\":0,\"OUT24\":0,\"OUT25\":0,\"OUT26\":0,\"OUT27\":0,\"OUT28\":0,\"OUT29\":0,\"OUT30\":0,\"OUT31\":0,\"OUT32\":0}";

    [Fact]
    public void GivenActiveOutput_ParseResponse_ReturnsActive()
    {
        //Arrange
        var parser = new IPX800v3GetOutputHttpResponseParser();

        //Act
        OutputState response = parser.ParseResponse(jsonResponse, 2);
            
        //Assert
        Assert.Equal(OutputState.Active, response);
    }

    [Fact]
    public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
    {
        //Arrange
        var parser = new IPX800v3GetOutputHttpResponseParser();

        //Act
        OutputState response = parser.ParseResponse(jsonResponse, 1);
            
        //Assert
        Assert.Equal(OutputState.Inactive, response);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("{\"product\":\"IPX800_V3\",\"OUT1\":0}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800v3GetOutputHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 2));
    }
}