using IPX800cs.IO;
using IPX800cs.Parsers.v3.Legacy.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Legacy.M2M
{
    public class IPX800v3LegacyGetOutputM2MResponseParserTest
    {
        [Fact]
        public void GivenActiveOutput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v3LegacyGetOutputM2MResponseParser();
            var ipxResponse = "GetOut1=1";

            //Act
            OutputState response = parser.ParseResponse(ipxResponse, 3);
            
            //Assert
            Assert.Equal(OutputState.Active, response);
        }

        [Fact]
        public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v3LegacyGetOutputM2MResponseParser();
            var ipxResponse = "GetOut1=0";

            //Act
            OutputState response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(OutputState.Inactive, response);
        }
    }
}