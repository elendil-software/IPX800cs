using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetVirtualAnalogInputHttpResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v4GetVirtualAnalogInputHttpResponseParser();

            //Act
            double response = parser.ParseResponse(JsonResponse, 1);
            
            //Assert
            Assert.Equal(7410, response);
        }

        private const string JsonResponse = @"{
    ""product"": ""IPX800_V4"",
    ""status"": ""Success"",
    ""VA1"": 7410,
    ""VA2"": 0,
    ""VA3"": 0,
    ""VA4"": 0,
    ""VA5"": 0,
    ""VA6"": 0,
    ""VA7"": 0,
    ""VA8"": 0,
    ""VA9"": 0,
    ""VA10"": 0,
    ""VA11"": 0,
    ""VA12"": 0,
    ""VA13"": 0,
    ""VA14"": 0,
    ""VA15"": 0,
    ""VA16"": 0,
    ""VA17"": 0,
    ""VA18"": 0,
    ""VA19"": 0,
    ""VA20"": 0,
    ""VA21"": 0,
    ""VA22"": 0,
    ""VA23"": 0,
    ""VA24"": 0,
    ""VA25"": 0,
    ""VA26"": 0,
    ""VA27"": 0,
    ""VA28"": 0,
    ""VA29"": 0,
    ""VA30"": 0,
    ""VA31"": 0,
    ""VA32"": 0
}";
    }
}