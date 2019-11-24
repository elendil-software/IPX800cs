using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http
{
    public class IPX800v3AnalogInputHttpResponseTest
    {
        private const string jsonResponse = "{\"product\":\"IPX800_V3\",\"AN1\":0,\"AN2\":1,\"AN3\":0,\"AN4\":0,\"AN5\":0,\"AN6\":0,\"AN7\":0,\"AN8\":0,\"AN9\":0,\"AN10\":0,\"AN11\":0,\"AN12\":0,\"AN13\":0,\"AN14\":0,\"AN15\":0,\"AN16\":0}";
        
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse(int input, int expectedValue)
        {
            //Arrange
            var parser = new IPX800v3GetAnalogInputHttpResponseParser();

            //Act
            double response = parser.ParseResponse(jsonResponse, input);
            
            //Assert
            Assert.Equal(expectedValue, response);
        }
    }
}