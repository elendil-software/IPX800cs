using software.elendil.IPX800.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http
{
    public class IPX800v3GetVersionHttpResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsFirmwareVersion()
        {
            //Arrange
            var parser = new IPX800v3GetVersionHttpResponseParser();

            //Act
            string firmwareVersion = parser.ParseResponse(IPX800v3HttpResponse.Xml);
            
            //Assert
            Assert.Equal("3.05.62", firmwareVersion);
        }
    }
}