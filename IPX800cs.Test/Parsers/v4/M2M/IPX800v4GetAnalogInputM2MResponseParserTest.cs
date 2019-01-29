using software.elendil.IPX800.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IPX800v4GetAnalogInputM2MResponseParserTest
    {
        private const string headedResponse = "A1=9232&A2=0&A3=0&A4=0\r\n";
        private const string response = "9216&0&0&0\r\n";
        
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v4GetAnalogInputM2MResponseParser();
             var ipxResponse = "";

            //Act
            double response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(1, response);
        }
    }
}