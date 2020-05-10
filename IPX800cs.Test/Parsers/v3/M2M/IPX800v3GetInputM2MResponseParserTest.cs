using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.M2M
{
    public class IPX800v3GetInputM2MResponseParserTest
    {
        [Fact]
        public void GivenActiveInput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v3GetInputM2MResponseParser();
            var ipxResponse = "1\r\n";

            //Act
            InputState response = parser.ParseResponse(ipxResponse, 1);
            
            //Assert
            Assert.Equal(InputState.Active, response);
        }

        [Fact]
        public void GivenInactiveInput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v3GetInputM2MResponseParser();
            var ipxResponse = "0\r\n";

            //Act
            InputState response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(InputState.Inactive, response);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v3GetInputM2MResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
        }
    }
}