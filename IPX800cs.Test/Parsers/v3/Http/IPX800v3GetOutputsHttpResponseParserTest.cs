using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http;

public class IPX800v3GetOutputsHttpResponseParserTest
{
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800v3GetOutputsHttpResponseParser();
        var jsonResponse = "{\"product\":\"IPX800_V3\",\"OUT1\":0,\"OUT2\":1,\"OUT3\":1,\"OUT4\":0,\"OUT5\":0,\"OUT6\":1,\"OUT7\":0,\"OUT8\":0,\"OUT9\":0,\"OUT10\":0,\"OUT11\":0,\"OUT12\":0,\"OUT13\":0,\"OUT14\":0,\"OUT15\":0,\"OUT16\":0,\"OUT17\":0,\"OUT18\":0,\"OUT19\":0,\"OUT20\":0,\"OUT21\":0,\"OUT22\":0,\"OUT23\":0,\"OUT24\":0,\"OUT25\":0,\"OUT26\":0,\"OUT27\":0,\"OUT28\":0,\"OUT29\":0,\"OUT30\":0,\"OUT31\":0,\"OUT32\":0}";
        var expectedResponse = new Dictionary<int, OutputState>
        {
            {1, OutputState.Inactive},
            {2, OutputState.Active},
            {3, OutputState.Active},
            {4, OutputState.Inactive},
            {5, OutputState.Inactive},
            {6, OutputState.Active},
            {7, OutputState.Inactive},
            {8, OutputState.Inactive},
            {9, OutputState.Inactive},
            {10, OutputState.Inactive},
            {11, OutputState.Inactive},
            {12, OutputState.Inactive},
            {13, OutputState.Inactive},
            {14, OutputState.Inactive},
            {15, OutputState.Inactive},
            {16, OutputState.Inactive},
            {17, OutputState.Inactive},
            {18, OutputState.Inactive},
            {19, OutputState.Inactive},
            {20, OutputState.Inactive},
            {21, OutputState.Inactive},
            {22, OutputState.Inactive},
            {23, OutputState.Inactive},
            {24, OutputState.Inactive},
            {25, OutputState.Inactive},
            {26, OutputState.Inactive},
            {27, OutputState.Inactive},
            {28, OutputState.Inactive},
            {29, OutputState.Inactive},
            {30, OutputState.Inactive},
            {31, OutputState.Inactive},
            {32, OutputState.Inactive}
        };

        //Act
        Dictionary<int, OutputState> response = parser.ParseResponse(jsonResponse);
            
        //Assert
        Assert.Equal(expectedResponse, response);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800v3GetOutputsHttpResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
}