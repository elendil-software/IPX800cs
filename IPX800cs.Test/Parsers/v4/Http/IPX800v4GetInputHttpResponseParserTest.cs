using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetInputHttpResponseParserTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("[]")]
        [InlineData("{}")]
        [InlineData("{\"product\": \"IPX800_V4\",\"status\": \"Success\",\"D1\": 0}")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v4GetInputHttpResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
        }
        
        [Fact]
        public void GivenActiveInput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v4GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(IPX800v4JsonResponse.GetInputsJsonResponse, 4);
            
            //Assert
            Assert.Equal(InputState.Active, response);
        }

        [Fact]
        public void GivenInactiveInput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v4GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(IPX800v4JsonResponse.GetInputsJsonResponse, 2);
            
            //Assert
            Assert.Equal(InputState.Inactive, response);
        }
    }
}