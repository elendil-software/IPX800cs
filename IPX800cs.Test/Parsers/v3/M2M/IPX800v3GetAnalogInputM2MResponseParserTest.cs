using software.elendil.IPX800.Parsers.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.M2M
{
    public class IPX800v3GetAnalogInputM2MResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v3GetAnalogInputM2MResponseParser();
            var ipxResponse = "1\r\n";

            //Act
            double response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(1, response);
        }
    }
}