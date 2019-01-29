using software.elendil.IPX800.Parsers.v2.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.M2M
{
    public class IPX800v2SetOutputM2MResponseParserTest
    {
        [Fact]
        public void GivenSuccess_ParseResponse_ReturnsTrue()
        {
            //Arrange
            var parser = new IPX800v2SetOutputM2MResponseParser();
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
            var parser = new IPX800v2SetOutputM2MResponseParser();
            var ipxResponse = "";

            //Act
            bool response = parser.ParseResponse(ipxResponse);
            
            //Assert
            Assert.False(response);
        }
    }
}