using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetOutputHttpResponseParserTest
    {
        [Fact]
        public void GivenActiveOutput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v4GetOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(IPX800v4JsonResponse.GetOutputsJsonResponse, 3);
            
            //Assert
            Assert.Equal(OutputState.Active, response);
        }

        [Fact]
        public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v4GetOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(IPX800v4JsonResponse.GetOutputsJsonResponse, 2);
            
            //Assert
            Assert.Equal(OutputState.Inactive, response);
        }
    }
}