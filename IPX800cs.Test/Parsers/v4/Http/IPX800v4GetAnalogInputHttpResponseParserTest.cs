using IPX800cs.Parsers.v4.Http;
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
            double response = parser.ParseResponse(IPX800v4JsonResponse.GetAnalogInputsJsonResponse, 1);
            
            //Assert
            Assert.Equal(9919, response);
        }
    }
}