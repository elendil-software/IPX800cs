using IPX800cs.Exceptions;
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
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("<response><firmwareversion>??</firmwareversion></response>")]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
        {
            //Arrange
            var parser = new IPX800v2GetVersionHttpResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
        }
    }
}