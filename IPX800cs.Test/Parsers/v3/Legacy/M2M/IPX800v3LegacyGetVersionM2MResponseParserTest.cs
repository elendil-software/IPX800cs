using IPX800cs.Parsers.v3.Legacy.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Legacy.M2M
{
    public class IPX800v3LegacyGetVersionM2MResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsFirmwareVersion()
        {
            //Arrange
            var parser = new IPX800v3LegacyGetVersionM2MResponseParser();

            //Act
            string firmwareVersion = parser.ParseResponse("GetVersion=3.05.38\r\n");
            
            //Assert
            Assert.Equal("3.05.38", firmwareVersion);
        }
    }
}