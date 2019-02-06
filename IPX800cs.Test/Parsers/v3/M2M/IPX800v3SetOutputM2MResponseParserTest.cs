using IPX800cs.Parsers.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.M2M
{
    public class IPX800v3SetOutputM2MResponseParserTest
    {
        [Fact]
        public void GivenSuccess_ParseResponse_ReturnsTrue()
        {
            //Arrange
            var parser = new IPX800v3SetOutputM2MResponseParser();
            var ipxResponse = "OK\r\n";

            //Act
            bool response = parser.ParseResponse(ipxResponse);
            
            //Assert
            Assert.True(response);
        }

        [Fact]
        public void GivenError_ParseResponse_ReturnsFalse()
        {
            //Arrange
            var parser = new IPX800v3SetOutputM2MResponseParser();
            var ipxResponse = "Invalid response\r\n";

            //Act
            bool response = parser.ParseResponse(ipxResponse);
            
            //Assert
            Assert.False(response);
        }
    }
}