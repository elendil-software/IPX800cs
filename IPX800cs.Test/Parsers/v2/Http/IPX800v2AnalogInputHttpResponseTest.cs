using software.elendil.IPX800.Parsers.v2.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.Http
{
    public class IPX800v2AnalogInputHttpResponseTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v2AnalogInputHttpResponseParser();

            //Act
            double response = parser.ParseResponse(IPX800v2HttpResponse.Xml, 2);
            
            //Assert
            Assert.Equal(1, response);
        }
    }
}