using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5GetTimersResponseParserTest
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("{}")]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidResponse)
    {
        //Arrange
        var parser = new IPX800V5GetTemposResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
    }
        
    [Fact]
    public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
    {
        //Arrange
        var parser = new IPX800V5GetTemposResponseParser();
        var expectedResponse = new List<TimerResponse>
        {
            new() { Func = "tempo", Id = 1310720, Name = "TEMPO N°0", IoStartId = 65576},
            new() { Func = "tempo", Id = 1310722, Name = "TEMPO N°1", IoStartId = 65581},
            new() { Func = "tempo", Id = 1310723, Name = "TEMPO N°2", IoStartId = 65584},
            new() { Func = "tempo", Id = 1310727, Name = "TEMPO N°3", IoStartId = 65596},
            new() { Func = "tempo", Id = 1310728, Name = "TEMPO N°4 (Virtual IO)", IoStartId = 65604}
        };

        //Act
        List<TimerResponse> response = parser.ParseResponse(IPX800V5Response.Timers).ToList();
            
        //Assert
        Assert.Equal(expectedResponse.Count, response.Count);
        for (int i = 0; i < response.Count; i++)
        {
            Assert.Equal(expectedResponse[i].Func, response[i].Func);
            Assert.Equal(expectedResponse[i].Id, response[i].Id);
            Assert.Equal(expectedResponse[i].Name, response[i].Name);
            Assert.Equal(expectedResponse[i].IoStartId, response[i].IoStartId);
        }
    }
}