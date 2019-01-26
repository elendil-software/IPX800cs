using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http
{
    public class IPX800v2GetOutputHttpResponseParserTest
    {
        [Fact]
        public void GivenActiveOutput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v2GetOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(IPX800v2HttpResponse.Xml, 3);
            
            //Assert
            Assert.Equal(OutputState.Active, response);
        }

        [Fact]
        public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v2GetOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(IPX800v2HttpResponse.Xml, 2);
            
            //Assert
            Assert.Equal(OutputState.Inactive, response);
        }
    }
}