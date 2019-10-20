using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetInputHttpResponseParserTest
    {
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