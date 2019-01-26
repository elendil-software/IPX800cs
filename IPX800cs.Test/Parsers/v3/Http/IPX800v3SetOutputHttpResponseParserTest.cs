using software.elendil.IPX800.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http
{
    public class IPX800v3SetOutputHttpResponseParserTest
    {
        [Fact]
        public void GivenSuccess_ParseResponse_ReturnsTrue()
        {
            //Arrange
            var parser = new IPX800v3SetOutputHttpResponseParser();

            //Act
            bool response = parser.ParseResponse("OK");
            
            //Assert
            Assert.True(response);
        }  [Fact]
        public void GivenError_ParseResponse_ReturnsTrue()
        {
            //Arrange
            var parser = new IPX800v3SetOutputHttpResponseParser();

            //Act
            bool response = parser.ParseResponse("!Bad Command");
            
            //Assert
            Assert.False(response);
        }
    }
}