using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http
{
    public class IPX800v3GetOutputHttpResponseParserTest
    {
        [Fact]
        public void GivenActiveOutput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v3GetOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(IPX800v3HttpResponse.Xml, 2);
            
            //Assert
            Assert.Equal(OutputState.Active, response);
        }

        [Fact]
        public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v3GetOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(IPX800v3HttpResponse.Xml, 1);
            
            //Assert
            Assert.Equal(OutputState.Inactive, response);
        }
    }
}