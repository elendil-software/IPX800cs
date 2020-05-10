using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.M2M
{
    public class IPX800v3GetOutputM2MResponseParserTest
    {
        [Fact]
        public void GivenActiveOutput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v3GetOutputM2MResponseParser();
            var ipxResponse = "1\r\n";

            //Act
            OutputState response = parser.ParseResponse(ipxResponse, 3);
            
            //Assert
            Assert.Equal(OutputState.Active, response);
        }

        [Fact]
        public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v3GetOutputM2MResponseParser();
            var ipxResponse = "0\r\n";

            //Act
            OutputState response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(OutputState.Inactive, response);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v3GetOutputM2MResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
        }
    }
}