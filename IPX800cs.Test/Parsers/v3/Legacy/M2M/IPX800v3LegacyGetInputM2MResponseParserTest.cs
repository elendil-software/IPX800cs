using IPX800cs.IO;
using IPX800cs.Parsers.v3.Legacy.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Legacy.M2M
{
    public class IPX800v3LegacyGetInputM2MResponseParserTest
    {
        [Fact]
        public void GivenActiveInput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v3LegacyGetInputM2MResponseParser();
            var ipxResponse = "GetIn1=1";

            //Act
            InputState response = parser.ParseResponse(ipxResponse, 1);
            
            //Assert
            Assert.Equal(InputState.Active, response);
        }

        [Fact]
        public void GivenInactiveInput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v3LegacyGetInputM2MResponseParser();
            var ipxResponse = "GetIn1=0";

            //Act
            InputState response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(InputState.Inactive, response);
        }
    }
}