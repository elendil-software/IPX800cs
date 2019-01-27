using software.elendil.IPX800.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetAnalogInputHttpResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v4GetAnalogInputHttpResponseParser();

            //Act
            double response = parser.ParseResponse(JsonResponse, 1);
            
            //Assert
            Assert.Equal(9919, response);
        }

        private const string JsonResponse = @"{
    ""product"": ""IPX800_V4"",
    ""status"": ""Success"",
    ""A1"": 9919,
    ""A2"": 0,
    ""A3"": 0,
    ""A4"": 0
}";
    }
}