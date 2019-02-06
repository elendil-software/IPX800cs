using IPX800cs.Parsers.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.M2M
{
    public class IPX800v3GetVersionM2MResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsFirmwareVersion()
        {
            //Arrange
            var parser = new IPX800v3GetVersionM2MResponseParser();

            //Act
            string firmwareVersion = parser.ParseResponse("3.05.62\r\n");
            
            //Assert
            Assert.Equal("3.05.62", firmwareVersion);
        }
    }
}