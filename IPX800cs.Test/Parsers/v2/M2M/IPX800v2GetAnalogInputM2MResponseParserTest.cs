using software.elendil.IPX800.Parsers.v2.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.M2M
{
    public class IPX800v2GetAnalogInputM2MResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v2GetAnalogInputM2MResponseParser();
            var ipxResponse = "GetAn1=123\r\n";

            //Act
            double response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(123, response);
        }
    }
}