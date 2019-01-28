using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http
{
    public class IPX800v2GetInputHttpResponseParserTest
    {
        [Fact]
        public void GivenActiveInput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v2GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(IPX800v2HttpResponse.Xml, 1);
            
            //Assert
            Assert.Equal(InputState.Active, response);
        }

        [Fact]
        public void GivenInactiveInput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v2GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(IPX800v2HttpResponse.Xml, 2);
            
            //Assert
            Assert.Equal(InputState.Inactive, response);
        }
    }
}