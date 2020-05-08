using IPX800cs.Exceptions;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetVirtualAnalogInputHttpResponseParserTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("[]")]
        [InlineData("{}")]
        [InlineData("{\"product\": \"IPX800_V4\",\"status\": \"Success\",\"VA1\": 0}")]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v4GetVirtualAnalogInputHttpResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
        }
        
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v4GetVirtualAnalogInputHttpResponseParser();

            //Act
            double response = parser.ParseResponse(IPX800v4JsonResponse.GetVirtualAnalogInputsJsonResponse, 1);
            
            //Assert
            Assert.Equal(7410, response);
        }
    }
}