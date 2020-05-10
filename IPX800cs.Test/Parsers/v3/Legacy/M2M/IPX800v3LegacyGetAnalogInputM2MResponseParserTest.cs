using IPX800cs.Exceptions;
using IPX800cs.Parsers.v3.Legacy.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Legacy.M2M
{
    public class IPX800v3LegacyGetAnalogInputM2MResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v3LegacyGetAnalogInputM2MResponseParser();
            var ipxResponse = "GetAn1=512";

            //Act
            double response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(512, response);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v3LegacyGetAnalogInputM2MResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
        }
    }
}