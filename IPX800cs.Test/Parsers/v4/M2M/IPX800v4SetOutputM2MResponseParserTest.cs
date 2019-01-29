using software.elendil.IPX800.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IPX800v4SetOutputM2MResponseParserTest
    {
        [Fact]
        public void GivenSuccess_ParseResponse_ReturnsTrue()
        {
            //Arrange
            var parser = new IPX800v4SetOutputM2MResponseParser();
            var ipxResponse = "Success\r\n";

            //Act
            bool response = parser.ParseResponse(ipxResponse);
            
            //Assert
            Assert.True(response);
        }

        [Fact]
        public void GivenError_ParseResponse_ReturnsFalse()
        {
            //Arrange
            var parser = new IPX800v4SetOutputM2MResponseParser();
            var ipxResponse = "Invalid response\r\n";

            //Act
            bool response = parser.ParseResponse(ipxResponse);
            
            //Assert
            Assert.False(response);
        }
    }
}