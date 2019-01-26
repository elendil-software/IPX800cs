using software.elendil.IPX800.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http
{
    public class IPX800v3AnalogInputHttpResponseTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v3AnalogInputHttpResponseParser();

            //Act
            double response = parser.ParseResponse(IPX800v3HttpResponse.Xml, 2);
            
            //Assert
            Assert.Equal(1, response);
        }
    }
}