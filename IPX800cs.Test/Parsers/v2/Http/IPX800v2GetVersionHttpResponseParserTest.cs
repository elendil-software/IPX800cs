using IPX800cs.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http
{
    public class IPX800v2GetVersionHttpResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsFirmwareVersion()
        {
            //Arrange
            var parser = new IPX800v2GetVersionHttpResponseParser();

            //Act
            string firmwareVersion = parser.ParseResponse(IPX800v2HttpResponse.Xml);
            
            //Assert
            Assert.Equal("3.00.29", firmwareVersion);
        }
    }
}