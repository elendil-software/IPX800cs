using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http
{
    public class IPX800v3GetInputHttpResponseParserTest
    {
        [Fact]
        public void GivenActiveInput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v3GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(IPX800v3HttpResponse.Xml, 8);
            
            //Assert
            Assert.Equal(InputState.Active, response);
        }

        [Fact]
        public void GivenInactiveInput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v3GetInputHttpResponseParser();

            //Act
            InputState response = parser.ParseResponse(IPX800v3HttpResponse.Xml, 1);
            
            //Assert
            Assert.Equal(InputState.Inactive, response);
        }

        [Fact]
        public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException()
        {
            //Arrange
            var parser = new IPX800v3GetInputHttpResponseParser();
            var invalidResponse = "<response><btn0>??</btn0><btn1>up</btn1></response>";

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse, 1));
        }
    }
}