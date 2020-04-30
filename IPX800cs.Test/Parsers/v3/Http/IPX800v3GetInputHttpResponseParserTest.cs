using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http
{
    public class IPX800v3GetInputHttpResponseParserTest
    {
        private const string jsonResponse = "{\"product\":\"IPX800_V3\",\"IN1\":0,\"IN2\":0,\"IN3\":0,\"IN4\":0,\"IN5\":1,\"IN6\":1,\"IN7\":0,\"IN8\":1,\"IN9\":0,\"IN10\":0,\"IN11\":0,\"IN12\":0,\"IN13\":0,\"IN14\":0,\"IN15\":0,\"IN16\":0,\"IN17\":0,\"IN18\":0,\"IN19\":0,\"IN20\":0,\"IN21\":0,\"IN22\":0,\"IN23\":0,\"IN24\":0,\"IN25\":0,\"IN26\":0,\"IN27\":0,\"IN28\":0,\"IN29\":0,\"IN30\":0,\"IN31\":0,\"IN32\":0}";

        
        [Fact]
        public void GivenActiveInput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v3GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(jsonResponse, 8);
            
            //Assert
            Assert.Equal(InputState.Active, response);
        }

        [Fact]
        public void GivenInactiveInput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v3GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(jsonResponse, 1);
            
            //Assert
            Assert.Equal(InputState.Inactive, response);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("[]")]
        [InlineData("{}")]
        [InlineData("{\"product\":\"IPX800_V3\",\"IN1\":0}")]
        public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
        {
            //Arrange
            var parser = new IPX800v3GetInputHttpResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 2));
        }
    }
}