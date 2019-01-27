using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetInputHttpResponseParserTest
    {
        [Fact]
        public void GivenActiveInput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v4GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(JsonResponse, 4);
            
            //Assert
            Assert.Equal(InputState.Active, response);
        }

        

        [Fact]
        public void GivenInactiveInput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v4GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(JsonResponse, 2);
            
            //Assert
            Assert.Equal(InputState.Inactive, response);
        }
        
        public const string JsonResponse = @"{
    ""product"": ""IPX800_V4"",
    ""status"": ""Success"",
    ""D1"": 0,
    ""D2"": 0,
    ""D3"": 0,
    ""D4"": 1,
    ""D5"": 1,
    ""D6"": 1,
    ""D7"": 0,
    ""D8"": 0,
    ""D9"": 0,
    ""D10"": 0,
    ""D11"": 0,
    ""D12"": 0,
    ""D13"": 0,
    ""D14"": 0,
    ""D15"": 0,
    ""D16"": 0,
    ""D17"": 0,
    ""D18"": 0,
    ""D19"": 0,
    ""D20"": 0,
    ""D21"": 0,
    ""D22"": 0,
    ""D23"": 0,
    ""D24"": 0,
    ""D25"": 0,
    ""D26"": 0,
    ""D27"": 0,
    ""D28"": 0,
    ""D29"": 0,
    ""D30"": 0,
    ""D31"": 0,
    ""D32"": 0,
    ""D33"": 0,
    ""D34"": 0,
    ""D35"": 0,
    ""D36"": 0,
    ""D37"": 0,
    ""D38"": 0,
    ""D39"": 0,
    ""D40"": 0,
    ""D41"": 0,
    ""D42"": 0,
    ""D43"": 0,
    ""D44"": 0,
    ""D45"": 0,
    ""D46"": 0,
    ""D47"": 0,
    ""D48"": 0,
    ""D49"": 0,
    ""D50"": 0,
    ""D51"": 0,
    ""D52"": 0,
    ""D53"": 0,
    ""D54"": 0,
    ""D55"": 0,
    ""D56"": 0
}";
    }
}