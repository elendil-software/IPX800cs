using software.elendil.IPX800.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http
{
    public class IPX800v2SetOutputHttpResponseParserTest
    {
        [Fact]
        public void GivenSuccess_ParseResponse_ReturnsTrue()
        {
            //Arrange
            var parser = new IPX800v2SetOutputHttpResponseParser();

            //Act
            bool response = parser.ParseResponse("OK");
            
            //Assert
            Assert.True(response);
        }  [Fact]
        public void GivenError_ParseResponse_ReturnsFalse()
        {
            //Arrange
            var parser = new IPX800v2SetOutputHttpResponseParser();

            //Act
            bool response = parser.ParseResponse("!Bad Command");
            
            //Assert
            Assert.False(response);
        }
    }
}